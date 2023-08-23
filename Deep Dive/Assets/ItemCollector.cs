using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text textbox;
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pick-Up small"))
        {
            
            Destroy(collision.gameObject);
            score = score + 100;
            textbox.text = "Score: " + score;
        }

        if(collision.gameObject.CompareTag("Pick-Up big"))
        {
            
            Destroy(collision.gameObject);
            score = score + 500;
            textbox.text = "Score: " + score;
        }

    }
}
