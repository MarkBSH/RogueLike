using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    GameObject deathMenuObject;
    GameObject weaponUI;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        deathMenuObject = GameObject.Find("DeathMenu");
        deathMenuObject.SetActive(false);
        weaponUI = GameObject.Find("CurrentWeaponUI");
    }

    public void DeathMenuFunc()
    {
        weaponUI.SetActive(false);
        deathMenuObject.SetActive(true);
        animator.SetBool("HasDied", true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
