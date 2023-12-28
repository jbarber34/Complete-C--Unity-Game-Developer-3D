using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX;

    [SerializeField] GameObject[] meshChildren;

    void HideMeshInChildren()
    {
        foreach (GameObject part in meshChildren)
        {
            // HERE: Get the mesh renderer and box collider from the part
            MeshRenderer mesh = part.GetComponentInChildren<MeshRenderer>();
            mesh.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the level on collision with anything else
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        HideMeshInChildren();
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }
}
