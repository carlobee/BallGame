using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Control the movement of the ball */

public class moveBall : MonoBehaviour
{
    // speed
    public Vector3 leftRightMove;
    public Vector3 backForwardMove;

    // keys
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode backKey;
    public KeyCode forwardKey;

    // Update is called once per X seconds
    void FixedUpdate()
    {
        // add velocity value to current location to continuously move
        if (Input.GetKey(leftKey))
        {
            GetComponent<Rigidbody>().velocity += leftRightMove;
        }
        if (Input.GetKey(rightKey))
        {
            GetComponent<Rigidbody>().velocity -= leftRightMove;
        }
        if (Input.GetKey(forwardKey))
        {
            GetComponent<Rigidbody>().velocity += backForwardMove;
        }
        if (Input.GetKey(backKey))
        {
            GetComponent<Rigidbody>().velocity -= backForwardMove;
        }
    }
}
