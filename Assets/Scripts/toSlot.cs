using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class a : MonoBehaviour {
    public string levelName; // 關卡名稱
    private void Update() {
        if (Input.GetKeyDown(KeyCode.C)){
            SceneManager.LoadScene(levelName);
        }
    }

}
