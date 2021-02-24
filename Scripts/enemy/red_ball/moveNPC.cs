using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Move the enemies across the map */

public class moveNPC : MonoBehaviour
{
    [SerializeField]
    public Transform destination;
    public Transform player;
    public float distance;
    public float radius;

    NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Update()
    {
        // reference navMeshAgent component
        agent = this.GetComponent<NavMeshAgent>();


        // get distance between NPC and player
        distance = Vector3.Distance(player.position, transform.position);

        // if the player comes inside that radius, then NPC goes towards player
        if(distance <= radius)
        {
            agent.SetDestination(destination.transform.position);
        }
    }



}
