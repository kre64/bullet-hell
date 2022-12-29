using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhysics : MonoBehaviour
{
  public static void Knockback(Rigidbody2D rb, float knockbackForce, Vector2 knockbackDirection)
  {
    rb.AddForce(knockbackDirection * knockbackForce);
  }
}
