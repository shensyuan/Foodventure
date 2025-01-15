using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class PromptWord : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI text;
    Color color = new Color(0f, 0f, 0f,0f);

    void Start()
    {
        text.text = "Dosn't have enough money!";
        text.color = new Color(color.r, color.g, color.b, 0f);
        //show();
    }

    void Update() {
        //show();
    }
}
