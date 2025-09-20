using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAttacking playerAttacking;
    private MainWeaponInventory inventory;
    private float scrollDelay = 0.2f;
    private float scrollTimer = 0;

    void Update()
    {
        playerAttacking = FindObjectOfType<PlayerAttacking>();

        inventory = FindObjectOfType<MainWeaponInventory>();

        Timers();

        if (inventory.items.Count > 0)
        {
            if (inventory.items[inventory.currentItem].automatic)
            {
                if (Input.GetMouseButton(0))
                {
                    Attacking();
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Attacking();
                }
            }
        }

        if (scrollTimer > scrollDelay)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                playerAttacking.inventory.CycleWeapunUp();
                scrollTimer = 0;
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                playerAttacking.inventory.CycleWeapunDown();
                scrollTimer = 0;
            }
        }
    }

    private void Timers()
    {
        if (scrollTimer < scrollDelay)
        {
            scrollTimer += Time.deltaTime;
        }
    }

    private void Attacking()
    {
        StartCoroutine(playerAttacking.Attack());
    }
}
