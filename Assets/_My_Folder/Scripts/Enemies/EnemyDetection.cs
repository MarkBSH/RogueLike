using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private GameObject[] enemies;
    private bool hasLineOfSightPlayer = false;
    private bool hasLineOfSightAttack = false;

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, other.transform.position - transform.position);
        if (ray.collider != null)
        {
            hasLineOfSightPlayer = ray.collider.CompareTag("Player");
            hasLineOfSightAttack = ray.collider.CompareTag("Player Attack");
            if (hasLineOfSightPlayer || hasLineOfSightAttack)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<EnemyMovement>().playerDetected = true;
                }
            }
        }
    }
}
