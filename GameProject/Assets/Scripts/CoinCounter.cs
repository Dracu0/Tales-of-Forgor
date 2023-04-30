using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    Text cointText;

    // Start is called before the first frame update
    void Start()
    {
        cointText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set the current number of coins to display
        if (cointText.text != Coin.totalCoins.ToString())
        {
            cointText.text = Coin.totalCoins.ToString();
        }
    }
}

