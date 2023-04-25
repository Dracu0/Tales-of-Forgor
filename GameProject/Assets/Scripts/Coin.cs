using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Coin : MonoBehaviour
{
    //Keep track of total picked coins (Since the value is static, it can be accessed at "Coin.totalCoins" from any script)
    public static int totalCoins = 0;
    

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
        if (tag == "ReplayButton")
        {
            Coin.totalCoins = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (collision.CompareTag("Player"))
        {
            //Add coin to counter
            totalCoins++;
            //Test: Print total number of coins
            Debug.Log("You currently have " + Coin.totalCoins + " Coins.");
            //Destroy coin
            Destroy(gameObject);

        }
    }
}