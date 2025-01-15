using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruits; // 水果預製物
    public float spawnInterval = 1.0f; // 生成間隔
    public float spawnRangeX = 7.0f; // X 軸生成範圍

    void Start()
    {
        InvokeRepeating("SpawnFruit", 1f, spawnInterval);
    }

    void SpawnFruit()
    {
        if(FindFirstObjectByType<Score>().isEnd) {
            return;
        }
        int randomIndex = Random.Range(0, fruits.Length);
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX), 
            transform.position.y, 
            0
        );

        GameObject fruit = Instantiate(fruits[randomIndex], spawnPosition, Quaternion.identity);
        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(new Vector3(Random.Range(-3f, 3f), Random.Range(8f, 15f), 0), ForceMode.Impulse);
            rb.AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(1f, -1f), Random.Range(1f, -1f)), ForceMode.Impulse);
        }

        if (Random.Range(0f, 1f) < 0.3f) {
            SpawnFruit();
        }
    }
}
