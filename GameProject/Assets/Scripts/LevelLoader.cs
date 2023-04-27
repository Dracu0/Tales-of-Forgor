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
    /* public void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("GoToMain"))
         {
             SceneManager.LoadScene("Scenes/Menu/Menu");
             Coin.totalCoins = 0;
         }
     }*/

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }



    public void GoToMenu()
    {
        SceneManager.LoadScene("Scenes/Menu/Menu", LoadSceneMode.Single);
        Coin.totalCoins = 0;
        Cursor.visible = true;
    }
}
