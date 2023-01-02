using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : Weapon
{
  public RaycastWeaponData raycastWeaponData;
  public LineRenderer lineRenderer;

  protected int maxHeat = 100;
  protected int heat = 0;

  private int damage = 4;
  private int heatPerShot = 10;
  private int heatDecrement = 1;
  private float heatDecrementTime = 0.6f;
  private float knockbackForce = 5f;
  private float knockbackDelay = 0.1f;
  private float maxDistance = 100;
  private bool allowFire = true;

  void Awake()
  {
    AttachGameUI();
    SetWeaponValues(raycastWeaponData);
  }

  public override void Shoot()
  {
    if (allowFire)
    {
      Fire();
    }
  }

  public override void Fire()
  {
    RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, maxDistance);
    // TODO: Maybe add a SetHeat func
    heat = heat + heatPerShot > maxHeat ? maxHeat : heat + heatPerShot;
    SetHeatText(heat);

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

  public void SetWeaponValues(RaycastWeaponData raycastWeaponData)
  {
    this.damage = raycastWeaponData.damage;
    this.heatPerShot = raycastWeaponData.heatPerShot;
    this.heatDecrementTime = raycastWeaponData.heatDecrementTime;
    this.heatDecrement = raycastWeaponData.heatDecrement;
    this.maxHeat = raycastWeaponData.maxHeat;
    this.maxDistance = raycastWeaponData.maxDistance;
    this.knockbackForce = raycastWeaponData.knockbackForce;
    this.knockbackDelay = raycastWeaponData.knockbackDelay;
  }

  public IEnumerator RaycastShot()
  {
    lineRenderer.enabled = true;
    allowFire = false;

    if (heat >= maxHeat)
    {
      Debug.Log("OVERHEATING");
      lineRenderer.enabled = false;
      StartCoroutine(CooldownFromMaxHeat());
    }
    else
    {
      lineRenderer.enabled = false;
      yield return new WaitForSeconds(0.1f);
      allowFire = true;
      StopAllCoroutines();
      StartCoroutine(CooldownFromMaxHeat());
    }
  }

  public IEnumerator HeatCooldown()
  {
    yield return new WaitForSeconds(heatDecrementTime);
    DecrementHeat();
  }

  public IEnumerator CooldownFromMaxHeat()
  {
    while (heat > 0)
    {
      yield return new WaitForSeconds(heatDecrementTime);
      Debug.Log("OVERHEAT COOLINDOWN " + heat);
      DecrementHeat();
    }
    allowFire = true;
  }


  protected void SetHeatText(int heat)
  {
    gameUI.SetCurrentHeat(heat);
  }

  private void DecrementHeat()
  {
    bool isNegativeHeat = heat - heatPerShot < 0;

    if (isNegativeHeat)
    {
      heat = 0;
    }
    else
    {
      heat -= heatDecrement;
    }
    SetHeatText(heat);
  }
}
