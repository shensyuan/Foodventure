using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fruitcoll : MonoBehaviour {
    public AudioSource audioSource; // 連結到 AudioSource 組件
    public AudioClip soundEffect;   // 需要播放的音效
    public AudioClip soundEffectBomb;   // 需要播放的音效

    void Start() {
        BoxCollider2D bx;
        bx = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
    }

    void OnCollisionEnter2D(Collision2D coll) //傳入碰撞對象
   {
        if (coll.gameObject.tag == "orange") {
            if (audioSource != null && soundEffect != null) {
                audioSource.PlayOneShot(soundEffect);
            }
            float x = UnityEngine.Random.Range(-16.29f, 0.25f);
            coll.gameObject.transform.position = new Vector3(x, 811, 0);
            pointCounter.score++;
            Debug.Log(pointCounter.score);
        }

        if (coll.gameObject.tag == "bomb") {
            if (audioSource != null && soundEffectBomb != null) {
                audioSource.PlayOneShot(soundEffectBomb);
            }
            float x = UnityEngine.Random.Range(-16.29f, 0.25f);
            coll.gameObject.transform.position = new Vector3(x, 813, 0);
            pointCounter.score = pointCounter.score - 2;
            Debug.Log(pointCounter.score);
        }

        if (coll.gameObject.tag == "peach") {
            float x = UnityEngine.Random.Range(-16.29f, 0.25f);
            coll.gameObject.transform.position = new Vector3(x, 814, 0);
            pointCounter.score = pointCounter.score + 2;
            Debug.Log(pointCounter.score);
        }

        if (coll.gameObject.tag == "avocado") {
            float x = UnityEngine.Random.Range(-16.29f, 0.25f);
            coll.gameObject.transform.position = new Vector3(x, 817, 0);
            pointCounter.score = pointCounter.score + 3;
            Debug.Log(pointCounter.score);
        }

    }
}
