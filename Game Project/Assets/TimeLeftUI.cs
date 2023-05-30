using UnityEngine;
using UnityEngine.UI;

public class TimeLeftUI : MonoBehaviour
{
    Text timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft.text = Mathf.RoundToInt(CoinMiniGame.TimeLeft) + "s";
    }
}
