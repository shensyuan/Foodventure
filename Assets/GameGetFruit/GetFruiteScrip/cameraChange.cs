using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 按空白鍵切換場景
        {
            //SceneManager.LoadScene("testChangeScence"); // 替換為你的場景名稱
        }
    }
}
