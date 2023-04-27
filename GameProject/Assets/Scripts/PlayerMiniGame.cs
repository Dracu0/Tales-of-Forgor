using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMiniGame : MonoBehaviour
{
    public Transform player;

    public Rigidbody2D rb;

    public Camera cam;
    private float MaxWidth;
    private bool viradoDireita;
    private int previousSceneIndex;
    public GameObject open;
    public GameObject closed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        previousSceneIndex = PlayerPrefs.GetInt("previousSceneIndex");


        if (cam == null)
        {
            cam = Camera.main;
        }

        rb = GetComponent<Rigidbody2D>();
        Vector3 UpperC = new Vector3(Screen.width, Screen.height);
        Vector3 dim = cam.ScreenToWorldPoint(UpperC);
        MaxWidth = dim.x - GetComponent<Renderer>().bounds.extents.x;
        viradoDireita = true;

    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Mouse X");

        if ((dirX < 0 && viradoDireita) || (dirX > 0 && !viradoDireita)) Flip();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.gameObject.CompareTag("Coin"))
        {
            /*Destroy(collision.gameObject);
            ncoins--; 
        }*/

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
    }

    void Flip()
    {
        viradoDireita = !viradoDireita;
        Vector3 scale = transform.localScale;
        scale.x *= -1;       //scale.x= scale.x * (-1);
        transform.localScale = scale;
    }

    private void FixedUpdate()
    {
        Vector3 rawpos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPos = new Vector2(Mathf.Clamp(rawpos.x, -MaxWidth, MaxWidth), -7.0f);
        rb.MovePosition(targetPos);
    }
}
