using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Restart level */

public class restartLevel : MonoBehaviour
{
    // key
    [SerializeField]
    KeyCode restartKey;

    // tag
    [SerializeField]
    string restartIfCollidesWith;

    // restart level if key is pressed
    // update is called once per X milliseconds
    void Update()
    {
        if(Input.GetKey(restartKey))
        {
            // reload active scene to restart
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }


    // restart level if collision with object
    void OnCollisionEnter(Collision collision)
    {
        // only restart if the player tag object collides
        if (collision.collider.tag == restartIfCollidesWith)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
