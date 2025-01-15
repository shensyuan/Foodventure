using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class wallet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int score;
    public TextMeshProUGUI tmpText;
    public static bool changeScence = false;

    int wal;

    void Start()
    {
        wal = SlotController.wal;
        tmpText.text = wal.ToString();
        changeScence = false;
        score = 0;
        show();
    }

    void Update() {
        show();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
//pos 247,24
    private void show(){
        wal = SlotController.wal;
        tmpText.text = wal.ToString();
    }
}
