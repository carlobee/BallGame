using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* base class which initialises properties */

public class NPCBaseFSM : StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject opponent;
    public float speed = 2.0f;
    public float rotSpeed = 1.0f;
    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // set NPC to the object the animator is attached too
        NPC = animator.gameObject;
        // the player the enemy will attack
        opponent = NPC.GetComponent<enemyAI>().GetPlayer();
    }
}
