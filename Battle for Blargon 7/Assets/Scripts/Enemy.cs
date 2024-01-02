using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int scorePerDeath = 100;
    [SerializeField] int hitPoints = 5;

    public List<ParticleCollisionEvent> collisionEvents; // creating a list of particle collision events
    Color initialColor; // Marking the color of the enemy as a variable
    float hitColorModifier = 0f; // new variable so the enemy changes color to a reddish tone after being hit

    // Bring in the score board
    ScoreBoard scoreBoard;
    GameObject parentGameObject;


    void Start()
    {
        // Find the score board
        scoreBoard = FindObjectOfType<ScoreBoard>();

        // Find parent type
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");

        // creating the collision list
        collisionEvents = new List<ParticleCollisionEvent>();
        AddRigidbody();

    }

    void AddRigidbody()
    {
        // Add rigidbody to enemy
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem part = other.GetComponent<ParticleSystem>(); // *** important! Making a variable to access the particle system of the emmiting object, in this case, the lasers from my player ship.
        int numCollisionEvents = part.GetCollisionEvents(this.gameObject, collisionEvents);

        foreach (ParticleCollisionEvent collisionEvent in collisionEvents) //  for each collision, do the following:
        {
            Vector3 pos = collisionEvent.intersection; // the point of intersection between the particle and the enemy
            GameObject vfx = Instantiate(hitVFX, pos, Quaternion.identity); // creating the explosion effect.
            vfx.transform.parent = parentGameObject.transform; // making the explosion effect a child of the enemy, so it follows it around.
        }

        if (hitPoints >= 0)
        {
            ProcessHit();
        }
        else
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        scoreBoard.UpdateScore(scorePerDeath); // Raise points by 100 (deaths are more valuable than hits
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints--; // reduces the enemy's Health by 1
        scoreBoard.UpdateScore(scorePerHit); // raise score by 10 by each hit
        hitColorModifier = hitColorModifier + 0.1f; // increases this variable so the enemy gets redder and redder each time, by the next code:
        GetComponent<MeshRenderer>().material.color = new Color
       (initialColor.r + hitColorModifier, initialColor.g - hitColorModifier, initialColor.b - hitColorModifier, initialColor.a); // this code makes the enemy becomes the same color as it always was, with this extra hitColorModifier...
    }
}
