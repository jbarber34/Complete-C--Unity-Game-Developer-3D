using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Adds amount to maxHitPoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    int currentHitPoints = 0;
    // [SerializeField] ParticleSystem hitParticlePrefab;
    // [SerializeField] ParticleSystem deathParticlePrefab;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        // if (currentHitPoints <= 0)
        // {
        //     KillEnemy();
        // }
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
        // hitParticlePrefab.Play();
    }

    // void KillEnemy()
    // {
    //     ParticleSystem vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
    //     vfx.Play();
    //     float destroyDelay = vfx.main.duration;
    //     Destroy(vfx.gameObject, destroyDelay);
    //     Destroy(gameObject);
    // }
}
