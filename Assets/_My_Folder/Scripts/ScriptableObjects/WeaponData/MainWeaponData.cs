using UnityEngine;

[CreateAssetMenu]
public class MainWeaponData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;

    public GameObject weaponObject;
    public GameObject attackObject;

    public int startAmmoCount;
    public int maxAmmoCount;
    public bool hasInfiniteAmmo;
    public float fullReloadTime;
    public float timeBetweenShots;
    public float timeForAnimator;

    public int damage;
    public int velocity;

    public float recoil;

    public bool automatic;
}
