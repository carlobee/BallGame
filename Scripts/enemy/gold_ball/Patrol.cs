using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* the patrol state behaviour */

/* FSM code inspired by https://www.youtube.com/watch?v=tdYsq96kCYI */

public class Patrol : NPCBaseFSM
{
    // waypoints to increment over
    GameObject[] waypoints;
    int currentWP;

    void Awake()
    {
        // add objects with tag 'waypoint' to list of waypoints
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        // start at position zero if it has been chasing
        currentWP = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // calcualte distance to check where NPC is in relation to current waypoint
        if (Vector3.Distance(waypoints[currentWP].transform.position,
            NPC.transform.position) < accuracy)
        {
            //if reached, get new waypoint
            currentWP++;

            // cycles around waypoints (a circuit)
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }

        // rotate NPC towards target
        var direction = waypoints[currentWP].transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,
            Quaternion.LookRotation(direction),
            rotSpeed * Time.deltaTime);

        // move NPC forward
        NPC.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}