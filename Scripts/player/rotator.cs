using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotator : MonoBehaviour
{
    [SerializeField]
    Transform t;

    // Update is called once per X seconds
    void Update()
    {
        // copy position of object
        transform.position = t.position;
    }
}
