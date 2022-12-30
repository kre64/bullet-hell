using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackArea : MonoBehaviour
{
  public WeaponData weaponData;
  public float knockbackDelay;
  public float knockbackForce;
  public int damage;

  // Start is called before the first frame update
  void Start()
  {
    InitWeaponValues();
  }

  private void InitWeaponValues()
  {
    damage = weaponData.damage;
    knockbackForce = weaponData.knockbackForce;
    knockbackDelay = weaponData.knockbackDelay;
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.GetComponent<Health>() != null)
    {
      Health health = collider.GetComponent<Health>();
      health.Damage(damage);

      ObjectPhysics objectPhysics = collider.GetComponent<ObjectPhysics>();
      objectPhysics.Knockback(collider, transform, knockbackForce, knockbackDelay);
    }
  }
}
