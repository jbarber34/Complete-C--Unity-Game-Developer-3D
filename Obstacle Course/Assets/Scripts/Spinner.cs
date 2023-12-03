using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float xAngle = 0.0f;
    [SerializeField] float spinSpeed = 100.0f;
    [SerializeField] float zAngle = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Rotate clockwise on the y-axis
        transform.Rotate(xAngle, spinSpeed * Time.deltaTime, zAngle);
    }
}
