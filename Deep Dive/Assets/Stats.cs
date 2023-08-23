using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Debug.Log("hi");
        if (collision.gameObject.CompareTag("Swordfish"))
        {
            Debug.Log("Swordfish");
        }

        if (collision.gameObject.CompareTag("Seekerfish"))
        {

            Debug.Log("Seekerfish");
        }

        if (collision.gameObject.CompareTag("Mine"))
        {

            Debug.Log("Mine");
        }

    }


}
