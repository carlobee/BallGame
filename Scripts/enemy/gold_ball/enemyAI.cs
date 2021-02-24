using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyAI : MonoBehaviour
{
    Animator animator;
    public GameObject player;

    //getter method for player
    public GameObject GetPlayer()
    {
        return player;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        // sets the distance val to the distance between the enemy and our player
        animator.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
    }
}
