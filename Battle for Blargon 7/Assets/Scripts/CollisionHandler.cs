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

    bool collisionDisabled = false;

    // TODO: REMOVE THIS BEFORE FINAL BUILD OR PUBLISHING SO PLAYERS CAN'T CHEAT!!!
    void Update()
    {
        RespondToDebugKeys();
    }

    void Defeat()
    {
        SceneManager.LoadScene(2);
    }

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
        if (!collisionDisabled) // Check if collision is enabled
        {
            StartCrashSequence();
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the level on collision with anything else
        SceneManager.LoadScene(currentSceneIndex);
    }

    //  Set up debug keys to test the game
    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle collision
            collisionDisabled = !collisionDisabled;
        }
    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        HideMeshInChildren();
        GetComponent<PlayerControls>().enabled = false;
        // This would reload level after a crasy
        // Invoke("ReloadLevel", levelLoadDelay);
        // This takes us to the defeat screen after a delay
        Invoke("Defeat", levelLoadDelay);
    }
}
