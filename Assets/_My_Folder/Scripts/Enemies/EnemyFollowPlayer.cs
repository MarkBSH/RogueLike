using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.up = player.transform.position - transform.position;
    }
}
