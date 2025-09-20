using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    public float health;

    void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Hurt(float DMG)
    {
        health -= DMG;

        enemyMovement.playerDetected = true;
    }
}
