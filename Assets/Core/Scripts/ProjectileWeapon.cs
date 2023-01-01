using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
  public WeaponData weaponData;
  public GameObject projectilePrefab;

  private int damage = 4;
  private float knockbackForce = 5f;
  private float knockbackDelay = 0.1f;
  private float maxDistance = 100;

  void Start()
  {
    SetWeaponValues(weaponData.damage, weaponData.maxDistance, weaponData.knockbackForce, weaponData.knockbackDelay);
  }

  public override void Shoot()
  {
    Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
  }

  public void SetWeaponValues(int damage, float maxDistance, float knockbackForce, float knockbackDelay)
  {
    this.damage = damage;
    this.maxDistance = maxDistance;
    this.knockbackForce = knockbackForce;
    this.knockbackDelay = knockbackDelay;
  }
}
