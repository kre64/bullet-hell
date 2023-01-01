using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  public Camera mainCamera;
  public Transform firePoint;

  public virtual void OnFire()
  {
    // Need this check because OnFire still invoked on disabled scripts
    if (this.enabled)
    {
      Shoot();
    }
  }

  public abstract void Shoot();
}
