using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PlayerProximity : MonoBehaviour
{

    public float activationDistance;
    public float deactivationDistance;
    public Transform player;
    private AIPath setter;
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
            setter.enabled = true;
        }
        if (deactivationDistance < Vector3.Distance(transform.position, player.position))
        {
            setter.enabled = false;
        }
    }
}
