using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame : MonoBehaviour
{
    private int previousSceneIndex;

    private void Start()
    {
        previousSceneIndex = PlayerPrefs.GetInt("previousSceneIndex");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("GoToMain"))
        {
            SceneManager.LoadScene("Scenes/Menu/Menu");
            Coin.totalCoins = 0;
        }
    }
}