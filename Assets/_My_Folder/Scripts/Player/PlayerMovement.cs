using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D RB2D;
    private Animator animator;
    private GameObject recoilTaker;
    private float moveX;
    private float moveY;
    private Vector2 movement;
    [SerializeField] private float moveSpeed;
    private bool WasW = true;
    private bool WasA = false;
    private bool WasS = false;
    private bool WasD = false;

    void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        recoilTaker = GameObject.Find("PlayerRecoil");
    }

    void Update()
    {
        MovementCalc();
    }

    void FixedUpdate()
    {
        Movement();
        Animating();
    }

    private void MovementCalc()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        movement = new Vector2(moveX, moveY);
    }

    private void Movement()
    {
        RB2D.MovePosition(RB2D.position + ((recoilTaker.GetComponent<Rigidbody2D>().velocity + (movement * moveSpeed)) * Time.fixedDeltaTime));
    }

    private void Animating()
    {
        if (movement.x < 0 && Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            WasW = false;
            WasA = true;
            WasS = false;
            WasD = false;
        }
        else if (movement.x > 0 && movement.x > Mathf.Abs(movement.y))
        {
            WasW = false;
            WasA = false;
            WasS = false;
            WasD = true;
        }
        else if (movement.y < 0 && Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
        {
            WasW = false;
            WasA = false;
            WasS = true;
            WasD = false;
        }
        else if (movement.y > 0 && movement.y > Mathf.Abs(movement.x))
        {
            WasW = true;
            WasA = false;
            WasS = false;
            WasD = false;
        }

        if (WasW)
        {
            animator.SetFloat("XSpeed", 0f);
            animator.SetFloat("YSpeed", 1f);
        }
        else if (WasA)
        {
            animator.SetFloat("XSpeed", -1f);
            animator.SetFloat("YSpeed", 0f);
        }
        else if (WasS)
        {
            animator.SetFloat("XSpeed", 0f);
            animator.SetFloat("YSpeed", -1f);
        }
        else if (WasD)
        {
            animator.SetFloat("XSpeed", 1f);
            animator.SetFloat("YSpeed", 0f);
        }

        if (movement.x != 0f || movement.y != 0f)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
}