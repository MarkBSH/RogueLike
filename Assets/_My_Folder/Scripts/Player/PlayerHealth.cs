using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D RB2D;
    private DeathMenu deathMenu;
    private CamDeathZoom camDeathZoom;
    public float health;

    void Awake()
    {
        animator = GetComponent<Animator>();
        RB2D = GetComponent<Rigidbody2D>();
        deathMenu = GameObject.Find("Canvas").GetComponent<DeathMenu>();
        camDeathZoom = GameObject.Find("Main Camera").GetComponent<CamDeathZoom>();
    }

    public void Hurt(float DMG)
    {
        health -= DMG;
        StartCoroutine(HurtAnim());
    }

    IEnumerator HurtAnim()
    {
        animator.SetBool("IsHurt", true);

        yield return new WaitForSeconds(1 / 12 * 6);

        animator.SetBool("IsHurt", false);

        if (health <= 0)
        {
            animator.SetBool("IsDead", true);

            Death();
        }
    }

    void Death()
    {
        RB2D.velocity = Vector2.zero;

        deathMenu.DeathMenuFunc();
        camDeathZoom.DeathZoom();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].GetComponent<EnemyAttacking>());
        }
        Destroy(GetComponent<MainWeaponInventory>().go);
        Destroy(GetComponent<MainWeaponInventory>());
        Destroy(GetComponent<PlayerAttacking>());
        Destroy(GetComponent<PlayerMovement>());
        Destroy(GetComponent<Player>());
        Destroy(this);
    }
}
