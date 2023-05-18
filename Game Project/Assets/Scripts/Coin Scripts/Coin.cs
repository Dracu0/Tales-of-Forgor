using UnityEngine;

public class Coin : MonoBehaviour
{
    //Keep track of total picked coins (Since the value is static, it can be accessed at "Coin.totalCoins" from any script)
    public static int totalCoins = 0;
    public static int playerScore = 0;
    public AudioSource coinSource;
    public float volume = 0.5f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (collision.CompareTag("Player"))
        {
            //Add coin to counter
            totalCoins++;
            playerScore++;
            //Test: Print total number of coins
            //Debug.Log("You currently have " + Coin.totalCoins + " Coins.");
            //Destroy coin
            PlayerPrefs.SetInt("PlayerScore", playerScore);
            coinSource.Play();
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("CoinDestroyer"))
        {
            Destroy(this.gameObject);

        }

    }

}