using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreCounter : MonoBehaviour
{
    Text playerScoreText;

    void Start()
    {
        playerScoreText = GetComponent<Text>();
    }

    private void Update()
    {
        if (playerScoreText.text != Coin.playerScore.ToString())
        {
            playerScoreText.text = Coin.playerScore.ToString();
        }
    }
}
