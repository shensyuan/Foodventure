using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public SlotReel[] reels; // 連結所有滾輪
    public float spinTime = 0f; // 滾輪旋轉的時間
    bool isSpinning = false;
    bool waitIn = false;
    bool textshow = false;
    public Transform[] bans;
    public SpriteRenderer[] result;
    public Transform[] resultpos;
    public Sprite[] images0;
    public Sprite[] images1;
    public Sprite[] images2;
    public TextMeshProUGUI text;
    public static int wal;
    Color color = new Color(0f, 0f, 0f,0f);

    void Start(){
        wal = PlayerPrefs.GetInt("Coin", 0);
    }

    public void StartSpin()
    {
        if(wal > 0){
            StartCoroutine(SpinReels());
        }else{
            text.color = new Color(color.r, color.g, color.b, 1f);
            StartCoroutine(FadeOutCoroutine());
        }
    } 
    void Update(){
        if(isSpinning || waitIn || textshow){
            spinTime += Time.deltaTime;
        }

        if(textshow && spinTime >= 10f){
            text.text = "";
            textshow = false;
        }

        if(waitIn && spinTime >= 5f){
            spinTime = 0f;
            result[0].sprite = null;
            result[1].sprite = null;
            result[2].sprite = null;
            resultpos[0].transform.position = new Vector3(-1000,-1000,0);
            resultpos[1].transform.position = new Vector3(-1000,-1000,0);
            resultpos[2].transform.position = new Vector3(-1000,-1000,0);
            waitIn = false;
        }
        if (isSpinning && spinTime >= 3.5f)
        {
            StopSpin();
            waitIn = true;

            reels[0].transform.position = new Vector3(-0.46f, 9.81f, 145.25f);
            reels[1].transform.position = new Vector3(-0.46f, 0.8f, 145.25f);
            reels[2].transform.position = new Vector3(2.93f, 9.81f, 145.25f);
            reels[3].transform.position = new Vector3(2.93f, 0.8f, 145.25f);
            reels[4].transform.position = new Vector3(6.38f, 9.81f, 145.25f);
            reels[5].transform.position = new Vector3(6.38f, 0.8f, 145.25f);

            bans[0].transform.position = new Vector3(-5.1677f,0.6806f,145.25f);
            bans[1].transform.position = new Vector3(-1.8f,0.6262f,145.25f);
            bans[2].transform.position = new Vector3(1.61f,0.6262f,145.25f);

            int idx0 = UnityEngine.Random.Range(0 , 9);
            int idx1 = UnityEngine.Random.Range(0 , 9);
            int idx2 = UnityEngine.Random.Range(0 , 9);
            result[0].sprite = images0[idx0];
            result[1].sprite = images1[idx1];
            result[2].sprite = images2[idx2];
            

            spinTime = 0f;
            isSpinning = false;
        }
    }

    private IEnumerator SpinReels()
    {
        if(wal > 0){
            spinTime = 0f;
            spinTime += Time.deltaTime;
            int i = 0;
            
            // 兩組交替啟動滾輪
            foreach (var reel in reels)
            {
                i++;
                reel.StartSpin();
                if (i % 2 == 0)
                {
                    yield return new WaitForSeconds(0.5f); // 停顿 0.9 秒后再启动下一组
                }
                isSpinning = true;
            }
        }
    }

    public void StopSpin()
    {
        foreach (var reel in reels)
        {
            reel.StopSpin();
        }
    }

    private IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;
        Color originalColor = text.color; // 獲取原始文字顏色

        while (elapsedTime < 3)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / 3); // 計算透明度
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha); // 設置新顏色
            yield return null;
        }

        // 確保最後完全透明
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}
