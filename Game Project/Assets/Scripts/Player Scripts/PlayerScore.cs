using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]public static int playerScore = 0;

    private void Update()
    {
        Coin.totalCoins += playerScore;
    }
}
