using UnityEngine;

public class MouseSpeed : MonoBehaviour
{
    public Vector3 mouseDelta = Vector3.zero;
    private Vector3 lastMousePosition = Vector3.zero;

    void Update()
    {
        mouseDelta = Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition;
    }
}
