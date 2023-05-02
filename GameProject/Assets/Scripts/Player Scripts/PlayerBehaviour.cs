using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private int PlayerDamage;
    [SerializeField] private int PlayerHeal;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerTakeHeal(PlayerHeal);
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
            PlayerTakeDamage(PlayerDamage);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
        }
    }

    private void PlayerTakeDamage(int damage)
    {
        GameManager.gameManager.playerHealth.DamageUnit(damage);
    }

    private void PlayerTakeHeal(int healing)
    {
        GameManager.gameManager.playerHealth.HealUnit(healing);
    }
}
