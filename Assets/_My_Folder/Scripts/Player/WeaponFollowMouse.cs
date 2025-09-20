using UnityEngine;

public class WeaponFollowMouse : MonoBehaviour
{
    private Vector3 mousePos;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.up = mousePos - transform.position;
    }
}
