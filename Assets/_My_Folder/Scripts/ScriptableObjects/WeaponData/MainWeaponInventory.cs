using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MainWeaponInventory : MonoBehaviour
{
    public List<MainWeaponInstance> items = new();
    public int currentItem = 0;
    [SerializeField] private GameObject attackPoint;
    [SerializeField] private CurrentWeaponUI currentWeaponUI;
    private bool hasWeapon = false;
    public GameObject go;

    public void AddItem(MainWeaponData newItemType)
    {
        items.Add(new MainWeaponInstance(newItemType));

        if (!hasWeapon)
        {
            hasWeapon = true;
            UpdateWeapon();
        }
    }

    public void CycleWeapunUp()
    {
        if (currentItem == items.Count - 1)
        {
            currentItem = 0;
        }
        else
        {
            currentItem += 1;
        }
        UpdateWeapon();
    }

    public void CycleWeapunDown()
    {
        if (currentItem == 0)
        {
            currentItem = items.Count - 1;
        }
        else
        {
            currentItem -= 1;
        }
        UpdateWeapon();
    }

    public void UpdateWeapon()
    {
        if (go != null)
        {
            Destroy(go);
        }

        go = Instantiate(items[currentItem].weaponObject, attackPoint.transform);

        currentWeaponUI.ChangeWeaponSprite(items[currentItem].itemType.icon);
    }
}
