using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static int playerScore;

    private void Update()
    {
        Coin.totalCoins += playerScore;
    }
}
