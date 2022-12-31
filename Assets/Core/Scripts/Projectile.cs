using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public Rigidbody2D rb;
  
  private int damage = 4;
  private float speed = 20f;
  private float knockbackForce = 5f;
  private float knockbackDelay = 0.1f;

  // Start is called before the first frame update
  void Start()
  {
    rb.velocity = transform.right * speed;
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("Enemy") && collider.GetComponent<Health>() != null)
    {
      Health health = collider.GetComponent<Health>();
      health.Damage(damage);

      ObjectPhysics objectPhysics = collider.GetComponent<ObjectPhysics>();
      objectPhysics.Knockback(collider, transform, knockbackForce, knockbackDelay);

      Destroy(gameObject);
    }
  }
}
