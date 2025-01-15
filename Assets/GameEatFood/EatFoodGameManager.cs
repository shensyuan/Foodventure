using System.Collections.Generic;  // 用於管理多個物件的清單
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EatFoodGameManager : MonoBehaviour {
    public GameObject platePrefab;
    public Button[] button;
    public float plateSpeed;
    public float timeRemaining;
    private bool isTimerRunning = false;
    public AudioSource audioSource; // 連結到 AudioSource 組件
    public AudioClip soundEffect;   // 需要播放的音效
    public AudioClip soundEffect1;   // 需要播放的音效

    public Text Score;
    public Text timerText;
    public int score;
    private List<GameObject> plates = new List<GameObject>();
    public Animator animator;
    private bool isMoving = false;
    public FoodController foodController;

    void Start() {

        initPlate();
        platePrefab.SetActive(false);

        // initBtn; 
        button[0].onClick.AddListener(() => btnClick(button[0].name));
        button[1].onClick.AddListener(() => btnClick(button[1].name));
        button[2].onClick.AddListener(() => btnClick(button[2].name));

        isTimerRunning = true;

    }

    void btnClick(string name) {
        animator.Play("Idle");
        if (plates != null) {
            try {
                GameObject child = plates[0].transform.Find(name).gameObject;
                if (child != null) {
                    if (audioSource != null && soundEffect1 != null) {
                        audioSource.PlayOneShot(soundEffect1);
                    }
                    Destroy(child);
                    score++;
                    animator.SetTrigger("eat");
                    animator.SetTrigger("idle");
                }
            }
            catch {
                if (audioSource != null && soundEffect != null) {
                    audioSource.PlayOneShot(soundEffect);
                }
                animator.SetTrigger("jump");
                animator.SetTrigger("idle");
            }
        }
    }


    void Update() {

        if (isTimerRunning) {
            if (plates != null && plates[0].transform.childCount == 0) {
                isMoving = true;
            }

            if (isMoving) {

                if (plates[1].transform.position.x < 0) {
                    MovePlates();
                }
                else {
                    isMoving = false;
                    Destroy(plates[0]);
                    plates.RemoveAt(0);
                    SpawnPlate(new Vector2(-10, -1));
                }
            }


            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else isTimerRunning = false;
            Score.text = $"Score : {score}";
        }

        if ((timeRemaining == 0 || score == 45)) {
            if (score >= 45) PlayerPrefs.SetInt("Success", 1);
            else PlayerPrefs.SetInt("Success", 0);
            SceneManager.LoadScene("Settlement");
        }

    }

    void initPlate() {
        Vector2[] platePositions = new Vector2[]{
            new Vector2(0, -1),
            new Vector2(-5, -1),
            new Vector2(-10, -1)
        };

        foreach (var position in platePositions) {
            SpawnPlate(position);
        }
    }
    void SpawnPlate(Vector2 position) {
        GameObject newPlate = Instantiate(platePrefab, position, Quaternion.identity);
        newPlate.SetActive(true);
        foodController.SpawnFoodOnPlate(newPlate.transform);
        plates.Add(newPlate);
    }

    void MovePlates() {
        for (int i = plates.Count - 1; i >= 0; i--) {
            if (plates[i] != null) {
                plates[i].transform.Translate(Vector3.right * plateSpeed * Time.deltaTime);
            }
        }
    }

    void UpdateTimerText() {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
