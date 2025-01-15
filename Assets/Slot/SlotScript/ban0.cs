using UnityEngine;
using UnityEngine.UI;

public class ban0 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button bu;
    public Button bu2;
    public Button bu3;
    public Transform[] result;
    public Transform[] bans;
    public AudioSource audioSource;
    public AudioClip soundEffect;
    int wal;
    void Start()
    {
        wal = SlotController.wal;
        bu.onClick.AddListener(() =>
        {
            wal = SlotController.wal;
            if(SlotController.wal > 0){
                SlotController.wal -= 50;
                Debug.Log($"Coin0: {SlotController.wal}");
                this.transform.position = new Vector3(-1000, -1000, 0);
                result[0].transform.position = new Vector3(-5.24f, 0.6f ,0f);
                bans[0].transform.position = new Vector3(-1000,-1000,0);   
                if (audioSource != null && soundEffect != null)
                {
                    audioSource.Play();
                }
            }
        });

        bu2.onClick.AddListener(Chick2);
        bu3.onClick.AddListener(Chick3);
    }

    void Chick2(){
        // if(SlotController.wal > 0){
        //     this.transform.position = new Vector3(-1000, -1000, 0);
        //     Debug.Log("50,100,150click");
        // }
    }

    void Chick3(){
        // if(SlotController.wal > 0){
        //     this.transform.position = new Vector3(-1000, -1000, 0);
        //     Debug.Log("50,100,150click");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
