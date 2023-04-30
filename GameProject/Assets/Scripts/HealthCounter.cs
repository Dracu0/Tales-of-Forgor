using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set the current number of coins to display
        if (healthText.text != GameManager.gameManager.playerHealth.Health.ToString())
        {
            healthText.text = GameManager.gameManager.playerHealth.Health.ToString();
        }
    }
}
