using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : Weapon
{
  public WeaponData raycastWeaponData;
  public LineRenderer lineRenderer;

  private int damage = 4;
  // private int ammo = 30;
  private float knockbackForce = 5f;
  private float knockbackDelay = 0.1f;
  private float maxDistance = 100;

  void Awake()
  {
    AttachGameUI();
  }

  void Start()
  {
    SetWeaponValues(raycastWeaponData.damage, raycastWeaponData.maxDistance, raycastWeaponData.knockbackForce, raycastWeaponData.knockbackDelay);
  }

  public override void Shoot()
  {
    RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, maxDistance);
    if (hitInfo)
    {
      bool isEnemy = hitInfo.collider.CompareTag("Enemy");
      bool hasHealth = hitInfo.collider.GetComponent<Health>() != null;

      if (isEnemy && hasHealth)
      {
        ObjectPhysics objectPhysics = hitInfo.collider.GetComponent<ObjectPhysics>();
        Health health = hitInfo.collider.GetComponent<Health>();
        health.Damage(damage);
        objectPhysics.Knockback(hitInfo.collider, firePoint, knockbackForce, knockbackDelay);
      }

      lineRenderer.SetPosition(0, firePoint.position);
      lineRenderer.SetPosition(1, hitInfo.point);
    }
    else
    {
      lineRenderer.SetPosition(0, firePoint.position);
      lineRenderer.SetPosition(1, firePoint.position + firePoint.right * maxDistance);
    }

    StartCoroutine(RaycastShot());
  }

  public void SetWeaponValues(int damage, float maxDistance, float knockbackForce, float knockbackDelay)
  {
    this.damage = damage;
    this.maxDistance = maxDistance;
    this.knockbackForce = knockbackForce;
    this.knockbackDelay = knockbackDelay;
  }

  public IEnumerator RaycastShot()
  {
    lineRenderer.enabled = true;
    yield return new WaitForSeconds(0.1f);
    lineRenderer.enabled = false;
  }
}
