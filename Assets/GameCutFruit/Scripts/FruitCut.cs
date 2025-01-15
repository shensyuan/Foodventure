using UnityEngine;
using System.Timers;
using Unity.VisualScripting; // 引入 Timer 命名空間

public class Cut : MonoBehaviour {
    public GameObject leftHalfPrefab;  // 左半水果 3D 模型
    public GameObject rightHalfPrefab; // 右半水果 3D 模型\
    [SerializeField] bool isBomb = false;
    private Score score;
    public float forceMagnitude = 5f; // 切割後的力大小
    public float destroyHeight = -20f;


    void Start() {
        score = FindFirstObjectByType<Score>(); // 獲取 Score 組件

    }

    void Update() {
        if (transform.position.y < destroyHeight) {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Blade")) // 檢測刀刃碰撞
        {

            if (!isBomb) {
                GetComponent<AudioSource>()?.Play();

                SliceFruit(); // 切割水果
                Vector3 newPosition = transform.position;
                newPosition.z -= 20f;
                transform.position = newPosition;
                score.AddScore(1); // 增加分數
            }
            else {

                Vector3 newPosition = transform.position;
                newPosition.z -= 20f;
                transform.position = newPosition;
                GetComponent<AudioSource>()?.Play();
                score.AddScore(-3);
            }

        }
    }

    void SliceFruit() {
        // 獲取當前水果的位置和旋轉
        Vector3 fruitPosition = transform.position;
        Quaternion fruitRotation = transform.rotation;

        // 生成左半水果
        GameObject leftHalf = Instantiate(leftHalfPrefab, fruitPosition, fruitRotation);
        Rigidbody leftRb = leftHalf.GetComponent<Rigidbody>();
        if (leftRb != null) {
            // 左半向左上方移動
            Vector3 leftForce = new Vector3(-1f, 1f, 0f) * forceMagnitude;
            leftRb.AddForce(leftForce, ForceMode.Impulse);
            leftRb.AddTorque(Random.insideUnitSphere * 200f); // 添加隨機旋轉
        }

        // 生成右半水果
        GameObject rightHalf = Instantiate(rightHalfPrefab, fruitPosition, fruitRotation);
        Rigidbody rightRb = rightHalf.GetComponent<Rigidbody>();
        if (rightRb != null) {
            // 右半向右上方移動
            Vector3 rightForce = new Vector3(1f, 1f, 0f) * forceMagnitude;
            rightRb.AddForce(rightForce, ForceMode.Impulse);
            rightRb.AddTorque(Random.insideUnitSphere * 200f); // 添加隨機旋轉
        }
        // Destroy(gameObject);
    }


}
