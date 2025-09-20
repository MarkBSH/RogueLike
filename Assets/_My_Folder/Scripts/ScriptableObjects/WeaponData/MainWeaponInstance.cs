using UnityEngine;

[System.Serializable]
public class MainWeaponInstance
{
    public MainWeaponData itemType;

    public GameObject weaponObject;
    public GameObject attackObject;

    public int ammo;
    public int fullAmmo;
    public int allAmmo;
    public bool hasInfiniteAmmo;
    public float fullReloadTime;
    public float timeBetweenShots;
    public float timeForAnimator;

    public int damage;
    public int velocity;

    public float recoil;

    public bool automatic;

    public MainWeaponInstance(MainWeaponData itemData)
    {
        itemType = itemData;

        weaponObject = itemData.weaponObject;
        attackObject = itemData.attackObject;

        ammo = itemData.startAmmoCount;
        allAmmo = itemData.maxAmmoCount;
        hasInfiniteAmmo = itemData.hasInfiniteAmmo;
        fullReloadTime = itemData.fullReloadTime;
        timeBetweenShots = itemData.timeBetweenShots;
        timeForAnimator = itemData.timeForAnimator;
        damage = itemData.damage;
        velocity = itemData.velocity;
        recoil = itemData.recoil;
        automatic = itemData.automatic;
    }
}
