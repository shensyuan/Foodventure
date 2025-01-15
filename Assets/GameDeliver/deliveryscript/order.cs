using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class order : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int orange;
    public TextMeshProUGUI tmpText;
    public static bool changeScence = false;

    void Start()
    {
        //tmpText.text = "score: 0 \nTimer: 60s";
        changeScence = false;
        orange = 0;
        show();
    }

    void Update() {
        show();
        //tmpText.text = player.gameover.ToString();
        // if (changeScence && Input.GetKeyDown(KeyCode.Space))
        // {
        //     SceneManager.LoadScene("Settlement");
        // }
    }
//pos 247,24
    private void show(){
        if(orange >= 6 && player.win){
            tmpText.text="            success!";
            changeScence = true;
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(-650, 200);
            PlayerPrefs.SetInt("Success", 1);
        }
        else if(player.gameover && !player.win){
            tmpText.text="             fail!";
            changeScence = true;
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(-650, 200);
            PlayerPrefs.SetInt("Success", 0);
        }
        else{
            //int time = (int)Math.Truncate(plate.timeCount);
            tmpText.text="order: "+orange.ToString()+"/6";
        }
    }
}
