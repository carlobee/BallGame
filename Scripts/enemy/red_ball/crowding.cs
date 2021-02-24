using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* class to control the behavior of the red balls when in crowds */
/* Inspired by https://www.youtube.com/watch?v=4CCAvUqAC7k */

public class crowding : MonoBehaviour
{
    // length of boundary
    [SerializeField]
    public float boundary;
    public float speed;
    public float direction;
    public float turn;
    public float turnspeed;
    Collider c;

    // Start is called before the first frame update
    void Start()
    {
        c = transform.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        int flag = 0;

        // right boundary
        if(Physics.Raycast(transform.position, transform.right, out hit, (boundary + transform.localScale.x)))
        {
            // check if the enemy object hits anything thats not obstacle or itsself
            if(hit.collider.tag != "Obstacle" || hit.collider == c)
            {
                return;
            }

            // turn left
            turn -= 1;
            flag++;
        }
        // left boundary
        if (Physics.Raycast(transform.position, -transform.right, out hit, (boundary + transform.localScale.x)))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == c)
            {
                return;
            }

            //turn right
            turn += 1;
            flag++;
        }
        // front boundary
        if (Physics.Raycast(transform.position, transform.forward, out hit, (boundary + transform.localScale.z)))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == c)
            {
                return;
            }
            if(direction == 1.0f)
            {
                //go back
                direction = -1;
            }
            flag++;
        }
        // back boundary
        if (Physics.Raycast(transform.position, -transform.forward, out hit, (boundary + transform.localScale.z)))
        {
            if (hit.collider.tag != "Obstacle" || hit.collider == c)
            {
                return;
            }
            if (direction == -1.0f)
            {
                //go forward
                direction = 1;
            }
            flag++;
        }

        if(flag == 0)
        {
            turn = 0;
        }

        // rotate
        transform.Rotate(Vector3.up * (turnspeed * turn) * Time.deltaTime);
        // move forward
        transform.position += transform.forward * (direction * speed) * Time.deltaTime;
    }

    
    /* draws gizmos as boundary points for enemy object */

void OnDrawGizmos()
    {
        // draw boundary from front
        Gizmos.DrawRay(transform.position, transform.forward * (boundary + transform.localScale.z));
        // draw boundary from back
        Gizmos.DrawRay(transform.position, -transform.forward * (boundary + transform.localScale.z));
        // draw boundary from right
        Gizmos.DrawRay(transform.position, transform.right * (boundary + transform.localScale.x));
        // draw boundary from left
        Gizmos.DrawRay(transform.position, -transform.right * (boundary + transform.localScale.x));
    }
}
