using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Menu/Menu");
        Coin.totalCoins = 0;
    }

}
