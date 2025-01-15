using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTrigger : MonoBehaviour
{
    public string levelName; // 關卡名稱
    public string displayLevelName; // 關卡名稱
    public GameObject levelPrompt; // 提示 UI
    private bool isPlayerInZone = false; // 玩家是否在觸發區

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
            levelPrompt.transform.Find("Text").GetComponent<Text>().text = $"{displayLevelName}\nPress \"Enter\" to enter the game.";
            levelPrompt.SetActive(true); // 顯示提示
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            levelPrompt?.SetActive(false); // 隱藏提示
        }
    }

    private void Update()
    {
        // 玩家在觸發區，且按下 "Enter" 鍵
        if (isPlayerInZone && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log($"切換到關卡: {levelName}");
            SceneManager.LoadScene(levelName); // 切換場景
        }
    }
}
