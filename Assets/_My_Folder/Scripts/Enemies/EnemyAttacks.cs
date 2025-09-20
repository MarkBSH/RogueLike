using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    private Rigidbody2D RB2D;
    private PlayerHealth playerHealth;
    [SerializeField] private float attackVelocity;
    [SerializeField] private float attackDMG;
    [SerializeField] private bool canPierceProjectiles = false;

    void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Velocity();
    }

    private void Velocity()
    {
        RB2D.velocity = transform.up * attackVelocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            playerHealth.Hurt(attackDMG);

            if (gameObject.CompareTag("Enemy Attack"))
            {
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Player Attack") && !canPierceProjectiles)
        {
            if (gameObject.CompareTag("Enemy Attack"))
            {
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Player Attack") && canPierceProjectiles)
        {
            Destroy(other);
        }

        if (other.gameObject.CompareTag("Walls"))
        {
            if (gameObject.CompareTag("Enemy Attack"))
            {
                Destroy(gameObject);
            }
        }
    }
}