using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName,LoadSceneMode.Single);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Scenes/Menu/Menu", LoadSceneMode.Single);
        Coin.totalCoins = 0;
    }

}
