using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    new MeshRenderer renderer;
    new Rigidbody rigidbody;
    [SerializeField] float waitTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Cache the MeshRenderer and RigidBody components
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();

        // Hide the oject at the start of the game
        renderer.enabled = false;

        // Set useGravity to false
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Drop the object after 5 seconds
        if (Time.time > waitTime)
        {
            // Show the object
            renderer.enabled = true;

            // Set useGravity to true
            rigidbody.useGravity = true;
        }
    }
}
