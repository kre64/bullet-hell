using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : Weapon
{
  public RaycastWeaponData raycastWeaponData;
  public LineRenderer lineRenderer;

  private int damage = 4;
  private float knockbackForce = 5f;
  private float knockbackDelay = 0.1f;

  void Start()
  {
    SetWeaponValues(raycastWeaponData.damage, raycastWeaponData.knockbackForce, raycastWeaponData.knockbackDelay);
  }

  public override void Shoot()
  {
    RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
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
      lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
    }

    StartCoroutine(RaycastShot());
  }

  public void SetWeaponValues(int damage, float knockbackForce, float knockbackDelay)
  {
    this.damage = damage;
    this.knockbackForce = knockbackForce;
    this.knockbackDelay = knockbackDelay;
  }

  public IEnumerator RaycastShot()
  {
    lineRenderer.enabled = true;
    yield return new WaitForSeconds(0.2f);
    lineRenderer.enabled = false;
  }
}
