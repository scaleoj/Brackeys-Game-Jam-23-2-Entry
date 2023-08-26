using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerProximity : MonoBehaviour
{
    public AudioSource audio;
    public float activationDistance;
    public float deactivationDistance;
    public Transform player;
    private AIPath setter;
    private bool aBool;
    // Start is called before the first frame update
    void Start()
    {
        setter = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activationDistance > Vector3.Distance(transform.position, player.position)) 
        {
            if(!aBool)
            {
                aBool= true;
                audio.Play();
                Debug.Log("Sound!");
            }
            
            
            setter.enabled = true;
            
        }
        if (deactivationDistance < Vector3.Distance(transform.position, player.position))
        {
            aBool = false;
            setter.enabled = false;
        }
    }
}
