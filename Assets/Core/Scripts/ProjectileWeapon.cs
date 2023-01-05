using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
  public ProjectileWeaponData projectileWeaponData;
  public GameObject projectilePrefab;

  protected int currentAmmo = 30;
  protected int maxAmmo = 30;

  protected bool reloading = false;

  void Awake()
  {
    SetWeaponValues(projectileWeaponData);
  }

  public override void Shoot()
  {
    if (currentAmmo > 0)
    {
      Fire();
    }
    else
    {
      Debug.Log("Out of ammo!");
    }
  }

  public override void Fire()
  {
    Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    currentAmmo--;
    SetAmmoText(currentAmmo);
  }

  public void SetWeaponValues(ProjectileWeaponData projectileWeaponData)
  {
    this.currentAmmo = projectileWeaponData.ammo;
    this.maxAmmo = projectileWeaponData.maxAmmo;
  }

  protected void SetAmmoText(int ammo)
  {
    gunUI.SetCurrentAmmo(currentAmmo);
  }
}
