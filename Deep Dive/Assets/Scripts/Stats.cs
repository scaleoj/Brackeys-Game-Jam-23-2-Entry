using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    public AudioSource drowning;
    public AudioSource breath;
    private bool drown;
    private bool bBool;


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
    private float deepest = 0;
    public float modifier = 4f;

    private bool isDead;
    

    void Start()
    {
        depletion = oxygendepletionrate;
        isDead= false;
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


        if (health <= 0 && !isDead)
        {

            EndScene();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Oxygen"))
        {
            
            depletion = 0f;
            if(!bBool)
            {
                bBool= true;
                breath.Play();
            }
            
        }
        if (collision.gameObject.CompareTag("Mine"))
        {

            health -= (int)((60f/ 100f)*damagemodifier);
            healthText.text = "Health: " + health;

        }
       

        if (health <= 0 && !isDead)
        {

            EndScene();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Oxygen"))
        {
            drowning.Stop();
            if (oxygen < 100f)
            {

                oxygen += 10f*Time.deltaTime;
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
            bBool= false;
        }
    }

    void Update()
    {
        depth = Mathf.Round(depthCheck.transform.position.y - transform.position.y);
        if(depth > deepest)
        {
            deepest = depth;
            gameManager.SetDepth(depth);
        }
        damagemodifier = (depth/10)*modifier;
        modifyText.text = "Depth: " + (int)(depth) + " (" + (int)damagemodifier + "% Damage)";
        oxygen -= depletion * Time.deltaTime;
        oxygenText.text = "Oxygen: " + (int)oxygen;
        if(oxygen <=50 && oxygen > 25)
        {
            oxygenText.color = new Color32(255, 255, 0, 255);
        }
        else if(oxygen<=25)
        {
            if(!drown)
            {
                drown= true;
                drowning.Play();
            }
            
            oxygenText.color = new Color32(255, 0, 0, 255);
            
        }else
        {
            oxygenText.color = new Color32(255, 255, 255, 255);
        }
        if (health <= 40)
        {
            healthText.color = new Color32(255, 0, 0, 255);
        }

        if (oxygen <= 0 && !isDead)
        {
            isDead= true;
            EndScene();
        }
    }

    void EndScene()
    {
        drowning.Stop();
        gameManager.GameOver();
    }


}
