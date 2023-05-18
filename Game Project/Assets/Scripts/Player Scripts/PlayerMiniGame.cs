using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMiniGame : MonoBehaviour
{
    public Transform player;

    public Rigidbody2D rb;

    public Camera cam;
    private bool viradoDireita;
    private int previousSceneIndex;
    public float maxMoveSpeed = 10f;

    Vector2 currentVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Scene currentScene = SceneManager.GetActiveScene();
        previousSceneIndex = PlayerPrefs.GetInt("previousSceneIndex");
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
        Cursor.lockState = CursorLockMode.Confined;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

    private void FixedUpdate()
    {
        float dirX = Input.GetAxisRaw("Mouse X");
        /*float dirXKeyBoard = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(dirXKeyBoard * maxMoveSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(dirXKeyBoard * maxMoveSpeed, 0);
        }*/

        if ((dirX < 0 && viradoDireita) || (dirX > 0 && !viradoDireita)) Flip();
         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         float currentY = transform.position.y; // get the current y-axis position
         mousePosition.y = currentY; // set the y-axis value to the current y-axis position
         rb.velocity = new Vector2(dirX * maxMoveSpeed, currentY);  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
