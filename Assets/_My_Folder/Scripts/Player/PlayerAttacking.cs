using System.Collections;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    private Animator animator;
    private PlayerStats playerStats;
    private GameObject attackPoint;
    private GameObject player;
    private GameObject recoilTaker;
    public MainWeaponInventory inventory;
    private float reloadTimer = 0;
    private float reloadTarget;
    private float shotTimer = 0;
    private float shotTarget;
    private float animatorTarget;

    void Awake()
    {
        animator = GetComponent<Animator>();

        playerStats = FindObjectOfType<PlayerStats>();

        attackPoint = GameObject.Find("PlayerAttackPoint");

        player = GameObject.Find("Player");

        recoilTaker = GameObject.Find("PlayerRecoil");

        inventory = player.GetComponent<MainWeaponInventory>();
    }

    void Update()
    {
        SetAttackSpeed();

        Timers();
    }

    private void SetAttackSpeed()
    {
        reloadTarget = inventory.items[inventory.currentItem].fullReloadTime * playerStats.attackSpeedMultiplier;

        shotTarget = inventory.items[inventory.currentItem].timeBetweenShots * playerStats.attackSpeedMultiplier;

        animatorTarget = inventory.items[inventory.currentItem].timeForAnimator * playerStats.attackSpeedMultiplier;

        animator.speed = playerStats.attackSpeedMultiplier;
    }

    private void Timers()
    {
        if (shotTimer < shotTarget)
        {
            shotTimer += Time.deltaTime;
        }

        if (reloadTimer < reloadTarget)
        {
            reloadTimer += Time.deltaTime;
        }
    }

    public IEnumerator Attack()
    {
        if (shotTimer > shotTarget && reloadTimer > reloadTarget)
        {
            animator.SetBool("StartAttack", true);

            shotTimer = 0;

            Vector3 velocity = transform.rotation * Vector3.down;
            recoilTaker.GetComponent<Rigidbody2D>().AddRelativeForce(velocity * inventory.items[inventory.currentItem].recoil, ForceMode2D.Force);

            yield return new WaitForSeconds(animatorTarget);

            Instantiate(inventory.items[inventory.currentItem].attackObject, attackPoint.transform.position, attackPoint.transform.rotation);

            animator.SetBool("StartAttack", false);

            LoseAmmo();

            if (inventory.items[inventory.currentItem].ammo <= 0)
            {
                reloadTimer = 0;
            }
        }
    }

    private void LoseAmmo()
    {
        inventory.items[inventory.currentItem].ammo -= 1;
        if (!inventory.items[inventory.currentItem].hasInfiniteAmmo)
        {
            inventory.items[inventory.currentItem].allAmmo -= 1;
        }
    }
}