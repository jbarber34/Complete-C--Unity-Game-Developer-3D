using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int hitPoints = 5;

    Color initialColor; // Marking the color of the enemy as a variable
    float hitColorModifier = 0f; // new variable so the enemy changes color to a reddish tone after being hit

    // Bring in the score board
    ScoreBoard scoreBoard;
    public List<ParticleCollisionEvent> collisionEvents;


    void Start()
    {
        // Find the score board
        scoreBoard = FindObjectOfType<ScoreBoard>();

        // creating the collision list
        collisionEvents = new List<ParticleCollisionEvent>();

    }

    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem part = other.GetComponent<ParticleSystem>(); // *** important! Making a variable to acess the particle system of the emmiting object, in this case, the lasers from my player ship.
        int numCollisionEvents = part.GetCollisionEvents(this.gameObject, collisionEvents);

        foreach (ParticleCollisionEvent collisionEvent in collisionEvents) //  for each collision, do the following:
        {
            Vector3 pos = collisionEvent.intersection; // the point of intersection between the particle and the enemy
            GameObject vfx = Instantiate(hitVFX, pos, Quaternion.identity); // creating the explosion effect.
            vfx.transform.parent = parent; // making the explosion effect a child of the enemy, so it follows it around.
        }
        ProcessHit();
    }

    void KillEnemy()
    {
        scoreBoard.UpdateScore(100); // Raise points by 100 (deaths are more valuable than hits
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        if (hitPoints >= 0) // that means, if the enemy is not dead yet...
        {
            hitPoints--; // reduces the enemy's Health by 1
            scoreBoard.UpdateScore(scorePerHit); // raise score by 10 by each hit
            hitColorModifier = hitColorModifier + 0.1f; // increases this variable so the enemy gets redder and redder each time, by the next code:
            GetComponent<MeshRenderer>().material.color = new Color
           (initialColor.r + hitColorModifier, initialColor.g - hitColorModifier, initialColor.b - hitColorModifier, initialColor.a); // this code makes the enemy becomes the same color as it always was, with this extra hitColorModifier...

        }
        else // if the enemy is dead...
        {
            KillEnemy();
        }

    }
}
