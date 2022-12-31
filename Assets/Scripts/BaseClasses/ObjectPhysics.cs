using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhysics : MonoBehaviour
{
  public void Knockback(Collider2D impactedBody, Transform impactOrigin, float knockbackForce, float knockbackDelay)
  {
    Vector2 knockbackDirection = (impactedBody.transform.position - impactOrigin.position).normalized;
    impactedBody.attachedRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    StartCoroutine(ResetKnockbackTargetVelocity(impactedBody.attachedRigidbody, knockbackDelay));
  }

  private IEnumerator ResetKnockbackTargetVelocity(Rigidbody2D knockbackTargetRb, float delaySeconds)
  {
    yield return new WaitForSeconds(delaySeconds);
    knockbackTargetRb.velocity = Vector2.zero;
  }
}
