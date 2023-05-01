using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    //this.gameObject.GetComponent<PlayerMovement>().enabled = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerHeal(25);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
        }

        if(GameManager.gameManager.playerHealth.Health == 0)
        {
            Destroy(gameObject.GetComponent<PlayerMovement>());
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            SceneManager.LoadScene("DeathScreen", LoadSceneMode.Single);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Spikes")
        {
            PlayerTakeDamage(50);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
        }
    }

    private void PlayerTakeDamage(int damage)
    {
        GameManager.gameManager.playerHealth.DamageUnit(damage);
    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager.playerHealth.HealUnit(healing);
    }
}
