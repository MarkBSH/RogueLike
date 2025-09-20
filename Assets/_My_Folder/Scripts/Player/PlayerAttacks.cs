using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private PlayerStats playerStats;
    private GameObject player;
    private MainWeaponInventory inventory;
    private Rigidbody2D RB2D;
    private EnemyHealth enemyHealth;
    private float attackSpeed;
    private float attackDMG;
    [SerializeField] private bool canPierceEnemies = false;
    [SerializeField] private bool canPierceAll = false;
    [SerializeField] private bool canPierceWalls = false;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        player = GameObject.Find("Player");
        inventory = player.GetComponent<MainWeaponInventory>();

        if (gameObject.CompareTag("Player Attack"))
        {
            RB2D = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        SetVelocity();

        SetDMG();

        if (gameObject.tag == "Player Attack")
        {
            Velocity();
        }
    }

    private void SetVelocity()
    {
        attackSpeed = inventory.items[inventory.currentItem].velocity * playerStats.attackVelocityMultiplier;
    }

    private void SetDMG()
    {
        attackDMG = inventory.items[inventory.currentItem].damage * playerStats.attackDMGMultiplier;
    }

    private void Velocity()
    {
        RB2D.velocity = transform.up * attackSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Walls") && !canPierceWalls)
        {
            if (gameObject.tag == "Player Attack")
            {
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Enemy") && !canPierceEnemies)
        {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

            enemyHealth.Hurt(attackDMG);

            if (gameObject.tag == "Player Attack")
            {
                Destroy(gameObject);
            }
        }

        if (other.gameObject.CompareTag("Enemy") && canPierceEnemies)
        {
            enemyHealth = other.gameObject.GetComponent<EnemyHealth>();

            enemyHealth.Hurt(attackDMG);
        }
    }
}