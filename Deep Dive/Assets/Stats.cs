using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Stats : MonoBehaviour
{
    public Animator anim;

    [SerializeField] TMP_Text healthText;
    public int health = 100;

    [SerializeField] TMP_Text oxygenText;
    public int oxygen = 100;
    public int oxygendepletionrate = 1;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Swordfish"))
        {
            health -= 20;
            healthText.text = "Health: " + health;

        }

        if (collision.gameObject.CompareTag("Seekerfish"))
        {
            health -= 40;
            healthText.text = "Health: " + health;
            
        }

        if (collision.gameObject.CompareTag("Mine"))
        {
            health -= 100;
            healthText.text = "Health: " + health;

        }

        if (health <= 0)
        {
            SceneManager.LoadScene("2DGameScene");
        }

    }


}
