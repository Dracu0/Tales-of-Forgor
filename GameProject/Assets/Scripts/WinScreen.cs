using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Scenes/Menu/Menu");
    }

}
