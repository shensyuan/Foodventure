using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class orange : MonoBehaviour
{
    public float initialTimer = -2f; // 初始 Timer 值
    //public int initialCycle = 811;
    public int cycle = 811;
    public static bool gameover = false;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float x = UnityEngine.Random.Range( -16.29f , 0.25f);
        this.transform.position = new Vector3(x,811,0);
        gameover = false;
        timer = initialTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameover){
            timer += Time.deltaTime;

            if (timer >= 0.01f)
            {
                timer = 0f;
                this.transform.position -= new Vector3(0,0.05f,0);
            }

            if(this.transform.position.y < 799){
                float x = UnityEngine.Random.Range( -16.29f , 0.25f);
                this.transform.position = new Vector3(x,cycle,0);
            }
        }

        if(pointCounter.score >= 80 || plate.timeCount >= 60f){
            timer = 0f;
            gameover = true;
        }

        if (pointCounter.changeScence && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Settlement");
        }
    }
}
