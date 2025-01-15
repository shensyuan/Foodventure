using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class pointCounter : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int score;
    public TextMeshProUGUI tmpText;
    public static bool changeScence = false;
    private float endTime = 3f;

    void Start() {
        tmpText.text = "score: 0 \nTimer: 60s";
        changeScence = false;
        score = 0;
        show();
    }

    void Update() {
        show();
        if (endTime <= 0) {
            SceneManager.LoadScene("Settlement");// 換到結算畫面
        }

    }
    //pos 247,24
    private void show() {
        if (score >= 80) {
            tmpText.text = "              success!";
            endTime -= Time.deltaTime;
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(-650, 200);
            PlayerPrefs.SetInt("Success", 1);
        }
        else if (plate.timeCount >= 60) {
            tmpText.text = "               fail!";
            endTime -= Time.deltaTime;
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(-650, 200);
            PlayerPrefs.SetInt("Success", 0);
        }
        else {
            int time = (int)Math.Truncate(plate.timeCount);
            tmpText.text = "score: " + score.ToString() + "\nTimer: " + time + "s";
        }
    }
}
