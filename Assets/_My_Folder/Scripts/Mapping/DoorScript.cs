using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;
    private DoorFunc doorFunc;
    public bool doorsOpened = false;
    private bool doorOpen = false;
    public bool doorLocked = true;
    [SerializeField] private bool sideDoor = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        doorFunc = GameObject.Find("GameManager").GetComponent<DoorFunc>();
    }

    public void UnlockDoor()
    {
        animator.SetBool("OpenClosed", true);

        doorLocked = false;
    }

    public void LockDoor()
    {
        if (doorOpen == false)
        {
            animator.SetBool("LockClosed", true);

            doorsOpened = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && doorLocked == false && doorsOpened == false)
        {
            animator.SetBool("OpenUnlocked", true);

            doorOpen = true;

            doorFunc.LockDoors();
        }
    }
}