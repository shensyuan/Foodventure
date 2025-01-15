using UnityEngine;
using UnityEngine.SceneManagement;

public class plate : MonoBehaviour
{
    public static bool gameover = false;
    bool left = true;
    bool right = true;
    public static float timeCount = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.position = new Vector3(-15, 801, 0);
        gameover = false;
    }
    //-16.04 ~ 0.06
    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(this.transform.position.x < -16.04){
            left = false;
        }else{
            left = true;
        }
        if(this.transform.position.x > 0.06){
            right = false;
        }else{
            right = true;
        }
        if(!gameover){
            int move = 5;
            if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
                move = 7;
            }
            if (Input.GetKey(KeyCode.D) && right)
            {
                this.transform.position += new Vector3(move * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.A) && left)
            {
                this.transform.position += new Vector3(-move * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.W)){
                this.transform.position += new Vector3(0, move * Time.deltaTime, 0);
            }
            if(Input.GetKey(KeyCode.S)){
                this.transform.position += new Vector3(0, -move * Time.deltaTime, 0);
            }
        }
        if(pointCounter.score >= 80 || timeCount >= 60f){
            gameover = true;
        }
    }
}
