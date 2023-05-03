using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    private int previousSceneIndex;
    public int coinReset = Coin.totalCoins;

    private void Start()
    {
        previousSceneIndex = PlayerPrefs.GetInt("previousSceneIndex");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }
    public void RePlayGame ()
    {
        SceneManager.LoadScene(previousSceneIndex);
        //Debug.Log(previousSceneIndex);
        Coin.totalCoins= 0;
        /*if (coinReset == 0)
        {
            Debug.Log("Coins have been reset!");
        }*/
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Menu/Menu");

        Coin.totalCoins = 0;
    }
}
