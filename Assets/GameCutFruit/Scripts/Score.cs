using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {
    private int score = 0;
    public bool isEnd = false;
    private float endTime = 3f;
    public TextMeshProUGUI resultText;
    void Start() {
        score = 0; // 初始化分數
    }

    void Update() {
        this.GetComponent<TextMeshProUGUI>().text = $"Score: {score}"; // 更新分數
        if (isEnd) {
            endTime -= Time.deltaTime;
            if (endTime <= 0) {
                SceneManager.LoadScene("Settlement");// 換到結算畫面
            }
        }
    }

    public void AddScore(int score) {
        this.score += score; // 增加分數
        if (this.score >= 15) {
            resultText.gameObject.SetActive(true);
            resultText.text = "You Win!";
            PlayerPrefs.SetInt("Success", 1);
            isEnd = true;
        }
        else if (this.score <= -5) {
            resultText.gameObject.SetActive(true);
            resultText.text = "You Lose!";
            PlayerPrefs.SetInt("Success", 0);
            isEnd = true;
        }

    }

}
