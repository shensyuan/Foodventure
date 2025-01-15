using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {
    [SerializeField] float XgenerateRange = 10f; // 生成範圍
    [SerializeField] float ZgenerateRange = 3f; // 生成範圍
    [SerializeField] int generateRate = 50;
    [SerializeField] List<GameObject> objects;
    [SerializeField] float gemerateTime = 5f;
    private float startTime = float.MinValue;
    public void StartGenerate() {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > startTime + gemerateTime) {
            return;
        }

        foreach (GameObject obj in objects) {
            Vector3 position = this.transform.position + new Vector3(
                Random.Range(-XgenerateRange, XgenerateRange),
                0,
                Random.Range(-ZgenerateRange, ZgenerateRange)
            );
            if (Random.Range(0, 1000) < generateRate) {
                GameObject new_obj = Instantiate(obj, position, Quaternion.identity);
                new_obj.GetComponent<Rigidbody>().AddTorque(new Vector3(
                    Random.Range(-3, 3),
                    Random.Range(-3, 3),
                    Random.Range(-3, 3)
                ));
            }
        }
    }
}
