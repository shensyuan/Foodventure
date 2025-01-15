using UnityEngine;

public class music : MonoBehaviour
{
    public AudioSource audioSource; // 連結到 AudioSource 組件
    public AudioClip soundEffect;   // 需要播放的音效

    void Start()
    {
        // 自動播放背景音樂
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    public void PlaySoundEffect()
    {
        // 播放一次性音效
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
    }
}

