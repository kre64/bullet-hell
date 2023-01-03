using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
  public Camera mainCamera;
  public Transform firePoint;

  protected GameUI gameUI;

  private void OnFire()
  {
    Shoot();
  }

  public abstract void Shoot();

  public abstract void Fire();

  protected void AttachGameUI()
  {
    gameUI = FindObjectOfType<GameUI>();
  }
}
