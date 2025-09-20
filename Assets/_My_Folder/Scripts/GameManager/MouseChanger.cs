using UnityEngine;

public class MouseChanger : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    private readonly CursorMode cursorMode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        SetCursor();
    }

    private void SetCursor()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
