using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class changeScene : MonoBehaviour {
    public string levelName; // 關卡名稱

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene(levelName);
        }
    }

}
