using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class PlayerMiniGameTest : MonoBehaviour
{
    public Transform player;

    public Rigidbody2D rb;

    public Camera cam;
    private bool viradoDireita;
    private int previousSceneIndex;
    public GameObject open;
    public GameObject closed;

    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;

    Vector2 currentVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        previousSceneIndex = PlayerPrefs.GetInt("previousSceneIndex");

        rb = GetComponent<Rigidbody2D>();

        viradoDireita = true;

        StartCoroutine(StartCursorLock());
    }

    IEnumerator StartCursorLock()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Mouse X");

        if ((dirX < 0 && viradoDireita) || (dirX > 0 && !viradoDireita)) Flip();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float currentY = transform.position.y; // get the current y-axis position
        mousePosition.y = currentY; // set the y-axis value to the current y-axis position
        Vector2 targetPosition = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
        transform.position = new Vector2(targetPosition.x, currentY); // only update the x-axis position
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == ("Spikes"))
        {
            Destroy(player.gameObject);
            player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            SceneManager.LoadScene(sceneName: "DeathScreen", LoadSceneMode.Single);
        }

        if (collision.gameObject.CompareTag("open"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Coin.totalCoins = 0;
        }

        if (collision.gameObject.CompareTag("tutorial"))
        {
            SceneManager.LoadScene(sceneName: "Level_Tutorial", LoadSceneMode.Single);
        }

        if (collision.gameObject.CompareTag("GoToMain"))
        {
            SceneManager.LoadScene("Scenes/Menu/Menu");
            Coin.totalCoins = 0;
        }

        if (collision.gameObject.CompareTag("BackToPreviousLevel"))
        {
            SceneManager.LoadScene(previousSceneIndex);
            Coin.totalCoins = 0;
        }

        if (collision.gameObject.CompareTag("MiniGame"))
        {
            SceneManager.LoadScene("Scenes/Levels/Level_MiniGame");
            Coin.totalCoins = 0;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Scenes/Menu/Menu", LoadSceneMode.Single);
            Coin.totalCoins = 0;
            Cursor.visible = true;
        }
    }

    void Flip()
    {
        viradoDireita = !viradoDireita;
        Vector3 scale = transform.localScale;
        scale.x *= -1;//scale.x= scale.x * (-1);
        transform.localScale = scale;
    }
}
