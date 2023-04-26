using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Scenes/Menu/LevelLoader");
        Coin.totalCoins = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}