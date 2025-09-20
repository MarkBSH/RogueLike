using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D RB2D;
    private SpriteRenderer spriteRenderer;
    private GameObject player;
    public GameObject attackPoint;
    public bool playerDetected;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxAttackRange;
    [SerializeField] private float minAttackRange;
    private float distToPlayer;


    void Awake()
    {
        animator = GetComponent<Animator>();
        RB2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");

        float temp = Random.Range(0f, 2f);
        if (temp < 1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void FixedUpdate()
    {
        GetDistance();

        if (playerDetected)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

            RotateSprite();

            Movement();

            animator.SetBool("IsRunning", true);
            animator.SetBool("IsIdle", false);
        }
    }

    private void GetDistance()
    {
        distToPlayer = Vector3.Distance(transform.position, player.transform.position);
    }

    private void RotateSprite()
    {
        if (RB2D.velocity.x > 0.001f)
        {
            spriteRenderer.flipX = false;
        }
        else if (RB2D.velocity.x < -0.001f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Movement()
    {
        if (distToPlayer >= maxAttackRange)
        {
            RB2D.velocity = attackPoint.transform.up * moveSpeed;
        }

        if (distToPlayer <= minAttackRange)
        {
            RB2D.velocity = -attackPoint.transform.up * moveSpeed;
        }

        if (distToPlayer <= maxAttackRange && distToPlayer >= minAttackRange)
        {
            RB2D.velocity = Vector3.zero;
        }
    }
}
