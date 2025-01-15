
using UnityEngine;
using UnityEngine.UI;

public class SlotMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundEffect;

    public Button bu1;
    public Button bu2;
    public Button bu3;

    void Start()
    {
        bu1.onClick.AddListener(Chick);
        bu2.onClick.AddListener(Chick);
        bu3.onClick.AddListener(Chick);

        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.playOnAwake = false;
        }
    }

    public void Chick()
    {
        // if (audioSource != null && soundEffect != null)
        // {
        //     audioSource.Play();
        // }
    }
}
