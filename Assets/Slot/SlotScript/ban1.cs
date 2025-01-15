using UnityEngine;
using UnityEngine.UI;

public class Ban1 : MonoBehaviour {
    // 按钮组件
    public Button bu;
    public Button bu2;
    public Button bu3;
    public Transform[] result;
    public Transform[] bans;
    public AudioSource audioSource;
    public AudioClip soundEffect;
    int wal;

    void Start() {
        bu2.onClick.AddListener(() => {
            wal = SlotController.wal;
            if (SlotController.wal > 0) {
                SlotController.wal -= 100;
                Debug.Log($"Coin1: {SlotController.wal}");
                this.transform.position = new Vector3(-1000, -1000, 0);
                result[0].transform.position = new Vector3(-5.24f, 0.6f, 0);
                result[1].transform.position = new Vector3(-1.86f, 0.6f, 0);
                bans[0].transform.position = new Vector3(-1000, -1000, 0);
                bans[1].transform.position = new Vector3(-1000f, -1000f, 0);
                if (audioSource != null && soundEffect != null) {
                    audioSource.Play();
                }
            }
        });

        bu3.onClick.AddListener(Chick3);
    }

    void Chick3() {
        // if(SlotController.wal > 0){
        //     this.transform.position = new Vector3(-1000, -1000, 0);
        //     Debug.Log("100,150click");
        // }
        // Debug.Log("click but no move");
    }
}
