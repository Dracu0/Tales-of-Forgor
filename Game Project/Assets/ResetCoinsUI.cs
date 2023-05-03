using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCoinsUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("MiniGameCoins");
    }

    public void ResetCoins()
    {
        Coin.totalCoins = 0;
        PlayerPrefs.SetInt("MiniGameCoins", Coin.totalCoins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
