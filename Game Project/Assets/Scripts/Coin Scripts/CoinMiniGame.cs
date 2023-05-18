using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinMiniGame : MonoBehaviour
{
    [SerializeField] private float MaxWidth;
    [SerializeField] private int CoinsToWin = 10;
    private int MiniGameCoins;
    public float waitingTimeCoin = 2.0f;
    public float waitingTimeSkull = 4.0f;
    public float timeForWinScreen = 2.0f;
    public float timeForDeathScreen = 2.0f;
    public float timeForPlayerDestroy = 2.0f;
    public GameObject coin;
    public GameObject skull;

    public void Start()
    {
        StartCoroutine(SpawnCoin());
        StartCoroutine(SpawnSkull());
        MiniGameCoins = Coin.totalCoins;
    }

    private void Update()
    {
        if (GameManager.gameManager.playerHealth.Health == 0)
        {
            DestroyAllObjects();
            StartCoroutine(Death());
        }
        if (Coin.totalCoins == 30)
        {
            DestroyAllObjects();
            StartCoroutine(Win());
        }
    }

    private void DestroyAllObjects()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("MiniGame");
        for (int i = 0; i < allObjects.Length; i++)
        {
            GameObject.Destroy(allObjects[i]);
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
        PlayerPrefs.Save();
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

    private IEnumerator SpawnCoin()
    {
        while (Coin.totalCoins < CoinsToWin)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-MaxWidth, MaxWidth), transform.position.y, 0.0f);
            Instantiate(coin, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(waitingTimeCoin);
        }
    }

    private IEnumerator SpawnSkull() 
    {
        while (Coin.totalCoins < CoinsToWin)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-MaxWidth, MaxWidth), transform.position.y, 0.0f);
            Instantiate(skull, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(waitingTimeSkull);
        }
    }

    private void OnDestroy()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("MiniGameCoins", Coin.totalCoins);
        PlayerPrefs.SetInt("previousSceneIndex", currentSceneIndex);
        PlayerPrefs.Save();
        Coin.totalCoins = 0;
        //Debug.Log(currentSceneIndex);
    }
}
