using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  public Camera mainCamera;
  public Transform firePoint;

  protected GameUI gameUI;

  public virtual void OnFire()
  {
    // Need this check because OnFire still invoked on disabled scripts
    if (this.enabled)
    {
      Shoot();
    }
  }

  public abstract void Shoot();

  protected void AttachGameUI()
  {
    gameUI = FindObjectOfType<GameUI>();
    Debug.Log(gameUI);
  }
}
