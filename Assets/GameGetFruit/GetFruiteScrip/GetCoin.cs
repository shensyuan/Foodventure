using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GetCoin : MonoBehaviour
{
    bool success;
    public int coin = 0;
    public TextMeshProUGUI tmpText;
    private void show(){
        success = PlayerPrefs.GetInt("Success", 0) == 1;
        int wallet = PlayerPrefs.GetInt("Coin", 0);
        if (success){
            coin = UnityEngine.Random.Range(100,0); 
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(200, 150);
            PlayerPrefs.SetInt("Coin", (coin+wallet));
            tmpText.text = "                      Win!\n            you get: " + coin.ToString() + " dollars\nPress Space return to to the main map";
        }else{
            coin = UnityEngine.Random.Range(100,0); 
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(200, 150);
            PlayerPrefs.SetInt("Coin", (-coin+wallet));
            tmpText.text = "                  Game Over!\n            you lose: -" + coin.ToString() + " dollars\nPress Space to return to the main map";
        }
    }    void Start()
    {
        tmpText.text = " ";
        show();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGameState();
            SceneManager.LoadScene("SampleScene");
        }
    }

    void ResetGameState()
    {
        pointCounter.score = 0;
        plate.timeCount = 0f;
        plate.gameover = false;
        orange.gameover = false;
    }

}
