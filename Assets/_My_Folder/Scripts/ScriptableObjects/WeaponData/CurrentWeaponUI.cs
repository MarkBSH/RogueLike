using UnityEngine;
using UnityEngine.UI;

public class CurrentWeaponUI : MonoBehaviour
{
    [SerializeField] private Image image;

    public void ChangeWeaponSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }
}
