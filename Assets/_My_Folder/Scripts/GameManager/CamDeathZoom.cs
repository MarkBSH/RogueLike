using UnityEngine;

public class CamDeathZoom : MonoBehaviour
{
    private new Camera camera;
    private bool HasDied = false;
    public float tempTime;

    void Awake()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (HasDied)
        {
            tempTime = Mathf.Lerp(1, 0.5f, 0 + 1f * Time.deltaTime);
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 5, 0 + (1f + (1 / tempTime)) * Time.deltaTime);
            Time.timeScale = tempTime;
        }
    }

    public void DeathZoom()
    {
        HasDied = true;
    }
}
