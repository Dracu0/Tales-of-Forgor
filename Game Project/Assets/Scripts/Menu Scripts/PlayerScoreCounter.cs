using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreCounter : MonoBehaviour
{
    Text playerScoreText;
    [SerializeField] private int playerScoreSaved;

    void Start()
    {
        playerScoreText = GetComponent<Text>();
    }

    private void Update()
    {
        playerScoreSaved = PlayerPrefs.GetInt("PlayerScore", Coin.playerScore);
        //Debug.Log(playerScoreSaved);
        if (playerScoreText.text != playerScoreSaved.ToString())
        {
            playerScoreText.text = playerScoreSaved.ToString();
        }
    }

}
