using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : Weapon
{
  public RaycastWeaponData raycastWeaponData;
  public LineRenderer lineRenderer;

  private const float MAX_HEAT = 1f;
  protected float heat = 0f;

  private int damage = 4;
  private float heatPerShot = 0.2f;
  private float heatCooldownRate = 0.6f;
  private float knockbackForce = 5f;
  private float knockbackDelay = 0.1f;
  private float maxDistance = 100;
  private bool allowFire = true;
  private bool overHeated = false;

  void Awake()
  {
    AttachGameUI();
    SetWeaponValues(raycastWeaponData);
  }

  void Update()
  {
    ReduceHeat();
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
    heat += heatPerShot;

    if (heat >= MAX_HEAT)
    {
      Debug.Log("OVERHEATED");
      overHeated = true;
      heat = MAX_HEAT;
    }

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

  private IEnumerator RaycastShot()
  {
    lineRenderer.enabled = true;
    allowFire = false;
    // TODO: Attack rate should be a property of the weapon
    yield return new WaitForSeconds(0.1f);
    lineRenderer.enabled = false;

    if (!overHeated)
    {
      allowFire = true;
    }
  }

  private void SetHeatText(float heat)
  {
    gameUI.SetCurrentHeat(heat);
  }

  private void SetWeaponValues(RaycastWeaponData raycastWeaponData)
  {
    this.damage = raycastWeaponData.damage;
    this.heatPerShot = raycastWeaponData.heatPerShot;
    this.heatCooldownRate = raycastWeaponData.heatCooldownRate;
    this.maxDistance = raycastWeaponData.maxDistance;
    this.knockbackForce = raycastWeaponData.knockbackForce;
    this.knockbackDelay = raycastWeaponData.knockbackDelay;
  }

  private void ReduceHeat()
  {
    heat = Mathf.Max(heat - heatCooldownRate * Time.deltaTime, 0f);
    SetHeatText(heat);

    if (heat == 0 && overHeated)
    {
      allowFire = true;
      overHeated = false;
    }
  }
}
