using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collisionInfo)
    {
        // Debug.Log(collisionInfo.collider.name + " bumped into a wall!");

        if (collisionInfo.gameObject.tag == "Player" && gameObject.name != "Start" && gameObject.name != "Finish")
        {
            // Change the color of the object that hit the wall to red
            GetComponent<MeshRenderer>().material.color = Color.red;

            // Change Tag of the object that hit the player to "Hit"
            // Including the collisionInfo. portion makes it so we're talking about the player, but leaving it out makes it so we're talking about the object
            gameObject.tag = "Hit";
        }

        if (collisionInfo.gameObject.tag == "Player" && (gameObject.name == "Start" || gameObject.name == "Finish"))
        {
            // Change the color of the object that hit the wall to red
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    // Optinoal turning color back to original if player isn't touching the obstacle
    private void OnCollisionExit(Collision collisionInfo)
    {
        // Debug.Log(collisionInfo.collider.name + " left the wall!");
        //     if (collisionInfo.gameObject.tag == "Player")
        //     {
        //         // Change the color of the object that hit the wall to clear
        //         GetComponent<MeshRenderer>().material.color = Color.clear;
        //     }

        if (collisionInfo.gameObject.tag == "Player" && (gameObject.name == "Start" || gameObject.name == "Finish"))
        {
            // Change the color of the object that hit the wall to clear
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
}
