using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackArea : MonoBehaviour
{
  public int damage = 3;

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.GetComponent<Health>() != null)
    {
      Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
      Health health = collider.GetComponent<Health>();

      health.Damage(damage);

      GamePhysics.Knockback(rb, 5f, transform.position + collider.transform.position);
    }
  }
}
