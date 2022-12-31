using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public int damage = 20;
  public float speed = 20f;
  public float knockbackForce = 1f;
  public float knockbackDelay = 0.15f;
  public Rigidbody2D rb;

  // Start is called before the first frame update
  void Start()
  {
    rb.velocity = transform.right * speed;
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.GetComponent<Health>() != null)
    {
      Health health = collider.GetComponent<Health>();
      health.Damage(damage);

      ObjectPhysics objectPhysics = collider.GetComponent<ObjectPhysics>();
      objectPhysics.Knockback(collider, transform, knockbackForce, knockbackDelay);

      Destroy(gameObject);
    }
  }
}
