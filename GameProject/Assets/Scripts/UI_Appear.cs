using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Appear : MonoBehaviour
{
    [SerializeField] private Text customText;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            customText.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            customText.enabled = false;
        }
    }

}
