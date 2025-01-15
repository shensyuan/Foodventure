using UnityEngine;

public class SetWallet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("Coin",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
