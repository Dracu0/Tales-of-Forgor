using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.GetInt("PlayerScore", Coin.playerScore);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Scenes/Menu/LevelLoader", LoadSceneMode.Single);
        Coin.totalCoins = 0;
    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt("MiniGameCoins", 0);
        PlayerPrefs.SetInt("PlayerScore", Coin.playerScore);
        Application.Quit();
    }
}