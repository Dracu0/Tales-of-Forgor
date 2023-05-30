using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinMiniGame : MonoBehaviour
{
    [SerializeField] private float MaxWidth;
    [SerializeField] private int CoinsToWin = 10;
    [SerializeField] public static float TimeLeft = 30f;
    [SerializeField] private float timeForStart = 2.0f;
    [SerializeField] private float timeForWinScreen = 2.0f;
    [SerializeField] private float timeForDeathScreen = 2.0f;
    [SerializeField] private float timeForPlayerDestroy = 2.0f;
    [SerializeField] private float waitingTimeCoin = 2.0f;
    [SerializeField] private float waitingTimeSkull = 5.0f;
    [SerializeField] private float waitingTimeHearth = 6.0f;
    [SerializeField] private Text gameStartText;
    private bool isPlaying = false;
    private int MiniGameCoins;
    public GameObject coin;
    public GameObject skull;
    public GameObject heart;

    public void Start()
    {
        StartCoroutine(GameStart());
        MiniGameCoins = Coin.totalCoins;
    }

    private void Update()
    {
        if (GameManager.gameManager.playerHealth.Health == 0 || TimeLeft <= 0)
        {
            isPlaying = false;
            DestroyAllObjects();
            StartCoroutine(Death());
        }

        if (Coin.totalCoins == CoinsToWin)
        {
            DestroyAllObjects();
            StartCoroutine(Win());
        }

        if(isPlaying)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                TimeLeft = 0;
                isPlaying=false;
            }
        }
        Debug.Log(TimeLeft);    
    }

    public void _TimeLeft()
    {
        TimeLeft -= Time.deltaTime;
    }

    private void DestroyAllObjects()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("MiniGame");
        for (int i = 0; i < allObjects.Length; i++)
        {
            GameObject.Destroy(allObjects[i]);
        }
    }

    private IEnumerator GameStart()
    {
        gameStartText.enabled = true;
        isPlaying = false;

        yield return new WaitForSeconds(timeForStart);

        gameStartText.enabled = false;
        isPlaying = true;

        StartCoroutine(SpawnCoin());
        StartCoroutine(SpawnSkull());
        StartCoroutine(SpawnHeart());

    }

    private IEnumerator Win()
    {
        isPlaying = false;
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
        isPlaying=false;
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
        while (TimeLeft > 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-MaxWidth, MaxWidth), transform.position.y, 0.0f);
            Instantiate(coin, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(waitingTimeCoin);
        }
    }

    private IEnumerator SpawnSkull() 
    {
        while (TimeLeft > 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-MaxWidth, MaxWidth), transform.position.y, 0.0f);
            Instantiate(skull, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(waitingTimeSkull);
        }
    }

    private IEnumerator SpawnHeart()
    {
        while (TimeLeft > 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-MaxWidth, MaxWidth), transform.position.y, 0.0f);
            Instantiate(heart, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(waitingTimeHearth);
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
