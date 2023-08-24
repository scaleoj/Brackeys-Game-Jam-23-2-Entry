using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProximity : MonoBehaviour
{

    [SerializeField] public GameObject player;
    public float proximity;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < proximity)
        {
            anim.SetFloat("distance", 7);
        }
        if (Vector3.Distance(transform.position, player.transform.position) >= proximity)
        {
            anim.SetFloat("distance", 11);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Seekerfish"))
        {
            anim.SetBool("explode", true);
            Destroy(collision.gameObject);
        }
    }

    void DeleteMe()
    {
        Destroy(gameObject);
    }
}
