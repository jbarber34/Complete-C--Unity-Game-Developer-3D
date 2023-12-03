using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Create initial variables and allow them to be used in the Unity Editor with the SerializeField attribute
    // [SerializeField] float xValue = 0.01f;
    // [SerializeField] float yValue = 0.0f;
    // [SerializeField] float zValue = 0.0f;

    // Control the speed of the movement and allow it to be used in the Unity Editor with the SerializeField attribute
    [SerializeField] float moveSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("Move your player with WASD or the arrow keys");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer()
    {
        // Move the player based on the input from the keyboard
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue, 0, zValue);
    }
}
