using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
  public ProjectileWeaponData projectileWeaponData;
  public GameObject projectilePrefab;

  private int currentAmmo = 30;
  private int maxAmmo = 30;
  private bool reloading = false;

  void Awake()
  {
    AttachGameUI();
  }

  void Start()
  {
    SetWeaponValues(projectileWeaponData);
  }

  public override void Shoot()
  {
    if (currentAmmo > 0)
    {
      Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
      currentAmmo--;
    }
    else {
      Debug.Log("Out of ammo!");
    }
  }

  public void SetWeaponValues(ProjectileWeaponData projectileWeaponData)
  {
    this.currentAmmo = projectileWeaponData.ammo;
    this.maxAmmo = projectileWeaponData.maxAmmo;
  }
}
