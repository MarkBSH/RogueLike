using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -10);
    }
}
