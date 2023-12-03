using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.name != "Ground" && collisionInfo.gameObject.tag != "Hit" && collisionInfo.gameObject.tag != "Safe")
        {
            hits++;
            Debug.Log("You've bumped into a thing this many times: " + hits);
        }
    }
}
