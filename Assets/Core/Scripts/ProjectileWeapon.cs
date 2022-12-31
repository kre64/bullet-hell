using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
  public GameObject projectilePrefab;

  public override void Shoot()
  {
    Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
  }
}
