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
    [SerializeField] private float waitingTimeMultiple = 1.0f;
    [SerializeField] private Text gameStartText;
    [SerializeField] private GameObject[] MGobjects;
    private bool isPlaying = false;
    private int MiniGameCoins;

    public void Start()
    {
        MiniGameCoins = Coin.totalCoins;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(GameStart());
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
        //Debug.Log(TimeLeft);    
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPlaying = false;

        yield return new WaitForSeconds(1);

        gameStartText.enabled = true;
        
        yield return new WaitForSeconds(timeForStart);

        gameStartText.enabled = false;
        isPlaying = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        StartCoroutine(SpawnMultiple());
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

    private IEnumerator SpawnMultiple()
    {
        while (TimeLeft > 0)
        {
            int randomIndex = Random.Range(0, MGobjects.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-MaxWidth, MaxWidth), transform.position.y, 0.0f);
            Instantiate(MGobjects[randomIndex], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(waitingTimeMultiple);
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
