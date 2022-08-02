using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDropper : MonoBehaviour
{
    [SerializeField] float timeToWait = 0.01f;
    MeshRenderer renderer;
    Rigidbody rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToWait)
        {
            renderer.enabled = true;
            rigidBody.useGravity = true;
        }
    }
}
