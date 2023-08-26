using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text textbox;
    public AudioSource small;
    public AudioSource big;

    public GameManager gameManager;

    public int smallScore = 100;
    public int largeScore = 100;
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pick-Up small"))
        {
            
            Destroy(collision.gameObject);
            score = score + smallScore;
            textbox.text = "Score: " + score;
            gameManager.SetScore(score);
            small.Play();
        }

        if(collision.gameObject.CompareTag("Pick-Up big"))
        {
            
            Destroy(collision.gameObject);
            score = score + largeScore;
            textbox.text = "Score: " + score;
            gameManager.SetScore(score);
            big.Play();
        }
    }
}
