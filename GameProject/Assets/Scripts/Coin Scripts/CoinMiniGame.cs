using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinMiniGame : MonoBehaviour
{
    [SerializeField] private float MaxWidth;
    public float waitingTime = 2.0f;
    public float timeForWinScreen = 2.0f;
    public float timeForDeathScreen = 2.0f;
    public float timeForPlayerDestroy = 2.0f;
    public GameObject coin;

    public void Start()
    {
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        if (GameManager.gameManager.playerHealth.Health == 0)
        {
            DestroyAllCoins();
            StartCoroutine(Death());
        }
        if (Coin.totalCoins == 30)
        {
            DestroyAllCoins();
            StartCoroutine(Win());
        }
    }

    private void DestroyAllCoins()
    {
        GameObject[] allCoins = GameObject.FindGameObjectsWithTag("MiniGame");
        for (int i = 0; i < allCoins.Length; i++)
        {
            GameObject.Destroy(allCoins[i]);
        }
    }

    private IEnumerator Win()
    {   
        yield return new WaitForSeconds(timeForPlayerDestroy);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Add a Player Death animation here where the player will be destroyed only after the animation is over
        Destroy(GameObject.FindWithTag("Player"));

        yield return new WaitForSeconds(timeForWinScreen);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
    }

    private IEnumerator Death()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Add a Player Death animation here where the player will be destroyed only after the animation is over
        Destroy(GameObject.FindWithTag("Player"));

        yield return new WaitForSeconds(timeForDeathScreen);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("DeathScreen", LoadSceneMode.Single);
    }

    private IEnumerator Spawn()
    {
        while (Coin.totalCoins < 30)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-MaxWidth, MaxWidth), transform.position.y, 0.0f);
            Instantiate(coin, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(waitingTime);
        }
    }

    private void OnDestroy()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("previousSceneIndex", currentSceneIndex);
        PlayerPrefs.Save();
        //Debug.Log(currentSceneIndex);
    }
}
