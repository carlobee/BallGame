using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* the attack state */

public class attack : NPCBaseFSM
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // rotate NPC towards target
        var direction = opponent.transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,
            Quaternion.LookRotation(direction),
            rotSpeed * Time.deltaTime);

        // move NPC to attack target
        NPC.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
