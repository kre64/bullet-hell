using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  public Camera mainCamera;
  public Transform firePoint;
  public GunUI gunUI;

  private void OnFire()
  {
    Shoot();
  }

  public abstract void Shoot();

  public abstract void Fire();

}
