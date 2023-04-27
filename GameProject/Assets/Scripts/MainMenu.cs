using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Scenes/Menu/LevelLoader", LoadSceneMode.Single);
        Coin.totalCoins = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}