using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {
    public TextMeshProUGUI timerText; // 用來顯示倒計時的 UI 元件
    public GameObject GameOverPanel; // 顯示失敗訊息的面板
    private float timeLeft = 30f;   // 倒計時的時間（秒）
    private float timeEnd = 7f;

    private bool isGameActive = true; // 遊戲是否正在進行

    void Start() {
        GameOverPanel.SetActive(false); // 隱藏失敗面板
        UpdateTimerUI(); // 初始化倒計時顯示
    }

    void Update() {
        if (isGameActive) {
            // 減少剩餘時間
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0) {
                // timeLeft = 0; // 確保時間不為負數
                GameOver(false);   // 倒計時結束時處理遊戲失敗
                if (timeLeft < -3)
                    SceneManager.LoadScene("Settlement");// 換到結算畫面
            }

            UpdateTimerUI();
        } 
        else {
            timeEnd -= Time.deltaTime;
            if (timeEnd < 0)
                SceneManager.LoadScene("Settlement");// 換到結算畫面
        }

        // else if (Input.GetKeyDown(KeyCode.Space)) //可以換場景
        // {
        //     SceneManager.LoadScene("Settlement");// 換到結算畫面
        // }
    }

    // 更新倒計時 UI
    void UpdateTimerUI() {
        timerText.text = $"Time left : {Mathf.Max(0, Mathf.Ceil(timeLeft))} s";
    }

    // 處理遊戲結束
    public void GameOver(bool isWin = false) {
        isGameActive = false; // 停止遊戲
        if (isWin) {
            GameOverPanel.GetComponent<TextMeshProUGUI>().text = "You Win!";
            PlayerPrefs.SetInt("Success", 1);
        }
        else {
            GameOverPanel.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            PlayerPrefs.SetInt("Success", 0);
        }
        GameOverPanel.SetActive(true); // 顯示失敗訊息
        Debug.Log("遊戲失敗！");
    }
}
