using UnityEngine;

public class SlotReel : MonoBehaviour
{
    public float speed = 5f; // 滾輪滾動速度
    public Transform[] symbols; // 滾輪上的符號
    public bool isSpinning = false;
    public float elapsedTime = 0f;

    // 用于记录初始位置
    private Vector3 initialPosition;

    void Start()
    {
        // 记录初始位置（Y 坐标）
        initialPosition = transform.position;
    }

    void Update()
    {
        if (isSpinning)
        {
            elapsedTime += Time.deltaTime;

            // 滚动逻辑
            this.transform.position -= new Vector3(0, 12f, 0);

            if (this.transform.position.y < -9.55f)
            {
                this.transform.position += new Vector3(0, 18.02f, 0); // 确保位置循环
            }
        }
    }

    public void StartSpin()
    {
        isSpinning = true;
        elapsedTime = 0f; // 重置计时
        this.transform.position = initialPosition;
    }

    public void StopSpin()
    {
        isSpinning = false;

        // 确保滚轮回到初始位置（y 间隔 1.81f）
        // float k = (SlotController.reels[2].transform.position.y - SlotController.reels[0].transform.position.y) % 1.81f;
        // if (k != 0)
        // {
        //     SlotController.reels[2].transform.position += new Vector3(0, k, 0);
        // }

        // 对齐回原始位置
        //this.transform.position = initialPosition;
    }
}
