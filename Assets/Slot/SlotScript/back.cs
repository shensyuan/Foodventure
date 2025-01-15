using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class back : MonoBehaviour
{
    public Button bu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bu.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("Coin", SlotController.wal);
            SceneManager.LoadScene("SampleScene");
        });

        if(Input.GetKeyDown(KeyCode.C)){
            PlayerPrefs.SetInt("Coin", SlotController.wal);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
