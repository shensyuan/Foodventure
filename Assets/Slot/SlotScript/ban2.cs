using UnityEngine;
using UnityEngine.UI;

public class ban2 : MonoBehaviour {
    // 按钮组件
    public Button bu;
    public Button bu2;
    public Button bu3;
    public Transform[] result;
    public Transform[] bans;
    public AudioSource audioSource;
    public AudioClip soundEffect;

    void Start() {
        bu3.onClick.AddListener(() => {
            int wal = SlotController.wal;
            if (SlotController.wal > 0) {
                SlotController.wal -= 150;
                Debug.Log($"Coin2: {SlotController.wal}");
                this.transform.position = new Vector3(-1000, -1000, 0);
                result[0].transform.position = new Vector3(-5.24f, 0.6f, 0);
                result[1].transform.position = new Vector3(-1.86f, 0.6f, 0);
                result[2].transform.position = new Vector3(1.47f, 0.6f, 0);
                bans[0].transform.position = new Vector3(-1000, -1000, 0);
                bans[1].transform.position = new Vector3(-1000f, -1000f, 0);
                bans[2].transform.position = new Vector3(-1000f, -1000f, 0);
                if (audioSource != null && soundEffect != null) {
                    audioSource.Play();
                }
                Debug.Log("150click");
            }
        });
    }
}
