using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
  public Camera mainCamera;
  public Transform firePoint;

  public virtual void OnFire()
  {
    Shoot();
  }

  public virtual void Shoot()
  {
    
  }
}
