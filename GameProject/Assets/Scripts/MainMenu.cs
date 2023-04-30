using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        BGMusic.instance.GetComponent<AudioSource>().Stop();
    }

    private void Start()
    {
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
        Application.Quit();
    }
}