using System.Collections;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private Animator animator;
    private GameObject player;

    private bool LOSPlayer = false;

    [SerializeField] private GameObject attackPoint;

    [SerializeField] private GameObject enemyBullet;

    [SerializeField] private float enemyAnimDelay;
    private float enemyDelayTarget;

    [SerializeField] private float enemyAttackSpeed;
    private float enemySpeedTarget;
    private float enemySpeedTimer = 0;

    void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    void Start()
    {
        enemyDelayTarget = enemyAnimDelay;
        enemySpeedTarget = enemyAttackSpeed;
    }

    void Update()
    {
        Timers();
    }

    private void Timers()
    {
        if (enemySpeedTimer < enemySpeedTarget)
        {
            enemySpeedTimer += Time.deltaTime;
        }
        else if (enemyMovement.playerDetected == true)
        {
            RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
            if (ray.collider != null)
            {
                LOSPlayer = ray.collider.CompareTag("Player");
                if (LOSPlayer)
                {
                    StartCoroutine(Attack());
                }
            }
        }
    }

    public IEnumerator Attack()
    {
        if (enemySpeedTimer > enemySpeedTarget)
        {
            animator.SetTrigger("StartAttack");

            enemySpeedTimer = 0;

            yield return new WaitForSeconds(enemyDelayTarget);

            Instantiate(enemyBullet, attackPoint.transform.position, attackPoint.transform.rotation);
        }
    }
}
