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
    public float oxygen = 100f;
    public float oxygendepletionrate = 1f;
    private float depletion;

    [SerializeField] GameObject depthCheck;
    [SerializeField] TMP_Text modifyText;
    private float damagemodifier = 1f;
    private float depth;

    void Start()
    {
        depletion = oxygendepletionrate;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Swordfish"))
        {
            health -= (int)((20f/100)*damagemodifier);
            healthText.text = "Health: " + health;

        }

        if (collision.gameObject.CompareTag("Seekerfish"))
        {
            health -= (int)((40f/100f)*damagemodifier);
            healthText.text = "Health: " + health;
            
        }


        if (health <= 0)
        {
            EndScene();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Oxygen"))
        {
            depletion = 0f;
        }
        if (collision.gameObject.CompareTag("Mine"))
        {

            health -= (int)((100f/ 100f)*damagemodifier);
            healthText.text = "Health: " + health;
            EndScene();

        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Oxygen"))
        {
            if(oxygen < 100f)
            {
                oxygen += 10f;
            }
            else if (oxygen > 100f)
            {
                oxygen = 100;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Oxygen"))
        {
            depletion = oxygendepletionrate;
        }
    }

    void Update()
    {
        depth = Mathf.Round(depthCheck.transform.position.y - transform.position.y);
        damagemodifier = (depth/10)*2;
        modifyText.text = "Depth: " + (int)(depth) + " (" + (int)damagemodifier + "% Damage)";
        oxygen -= depletion * Time.deltaTime;
        oxygenText.text = "Oxygen: " + (int)oxygen;
        if(oxygen <= 0)
        {
            EndScene();
        }
    }

    void EndScene()
    {
        SceneManager.LoadScene("2DGameScene");
    }


}
