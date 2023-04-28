using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform player;
   
    [SerializeField] 
    public float walkspeed;
    public float runspeed;
    public float friction;
    private bool doubleJump;
    public float groundRadius;
    public bool grounded;
    public Transform groundCheck;
    private Animator anim;
    private CapsuleCollider2D bc;
    public GameObject open;
    public GameObject closed;
    public GameObject tutorialText;
    public int ncoins;
    public LayerMask whatIsGround;
    private bool viradoDireita;
    private bool crouch;
    public bool running;
    public float JumpHeight;
    private int previousSceneIndex;
    private float dirX;
    public float doubleJumpHeight;

    private void Start()
    {
        open.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        player = player.transform;
        anim = GetComponent<Animator>();
        bc = GetComponent<CapsuleCollider2D>();
        viradoDireita = true;
        groundRadius = 0.2f;
        crouch = Input.GetKey(KeyCode.LeftControl);
        previousSceneIndex = PlayerPrefs.GetInt("previousSceneIndex");
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        
        float forceOfAcceleration = Mathf.Abs(rb.mass*Physics.gravity.y);

        if (grounded && !Input.GetKey(KeyCode.Space))
        {
            doubleJump = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJump ? doubleJumpHeight : JumpHeight);

                doubleJump = !doubleJump;

                anim.Play("Jump");
                anim.SetBool("Grounded", true);
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
            
        if (Input.GetKey(KeyCode.LeftShift) /*&& grounded*/)
        {
            rb.AddForce(new Vector2(rb.velocity.x * runspeed, 0f), ForceMode2D.Force);
            
            
            //Debug.Log(running);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("Crouch", true);
            crouch = true;
            bc.size = new Vector2(0.15f, 0.10f);
            bc.offset = new Vector2(0.0f, -0.05f);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("Crouch", false);
            crouch = false;
            bc.size = new Vector2(0.2f, 0.3f);
            bc.offset = new Vector2(0.0f, 0.0f);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetFloat("Speed", Mathf.Abs(dirX));
        if ((dirX < 0 && viradoDireita) || (dirX > 0 && !viradoDireita)) Flip(); 
        
        if (Coin.totalCoins == ncoins)
            {
                closed.SetActive(false);
                open.SetActive(true);
            }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * walkspeed, rb.velocity.y);
    }

    void Flip()
    {
        viradoDireita = !viradoDireita;
        Vector3 scale = transform.localScale;
        scale.x *= -1;       //scale.x= scale.x * (-1);
        transform.localScale = scale;
    }

    public void SceneNCoins()
    {
        int sceneNcoins = ncoins;
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
            SceneManager.LoadScene(sceneName:"DeathScreen", LoadSceneMode.Single);
            Debug.Log(collision);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.lockState = CursorLockMode.None;
        }

        if (collision.gameObject.CompareTag("open"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            Coin.totalCoins = 0;
        }

        if (collision.gameObject.CompareTag("tutorial"))
        {
            SceneManager.LoadScene(sceneName:"Level_Tutorial",LoadSceneMode.Single);
        }

        if (collision.gameObject.CompareTag("GoToMain"))
        {
            SceneManager.LoadScene("Scenes/Menu/Menu", LoadSceneMode.Single);
            Coin.totalCoins = 0;
        }

        if (collision.gameObject.CompareTag("BackToPreviousLevel"))
        {
            SceneManager.LoadScene(previousSceneIndex);
            Coin.totalCoins = 0;
        }

        if (collision.gameObject.CompareTag("MiniGame"))
        {
            SceneManager.LoadScene("Scenes/Levels/Level_MiniGame", LoadSceneMode.Single);
            Coin.totalCoins = 0;
        }

        if (collision.gameObject.CompareTag("TutorialTrigger"))
        {   
            tutorialText = gameObject.GetComponent<GameObject>();
        }

    }
    private void OnDisable()
    {
        if (tag == "Player")
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("previousSceneIndex", currentSceneIndex);
            PlayerPrefs.Save();
        }
    }

}