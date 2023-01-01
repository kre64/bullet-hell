using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhysics : MonoBehaviour
{
  public void Knockback(Collider2D impactedBody, Transform impactOrigin, float force, float delay)
  {
    float knockbackDelay = delay;
    float knockbackForce = force;
    bool resetToOrigin = false;

    if (impactedBody.GetComponent<TargetDummy>() != null)
    {
      knockbackDelay = 2f;
      resetToOrigin = true;
    }

    Vector2 knockbackDirection = (impactedBody.transform.position - impactOrigin.position).normalized;
    impactedBody.attachedRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    StartCoroutine(ResetKnockbackTargetVelocity(impactedBody.attachedRigidbody, knockbackDelay, resetToOrigin));
  }

  private IEnumerator ResetKnockbackTargetVelocity(Rigidbody2D rb, float seconds, bool resetToOrigin)
  {
    yield return new WaitForSeconds(seconds);
    rb.velocity = Vector2.zero;

    if (resetToOrigin)
    {
      rb.transform.position = new Vector3(5, 0, 0);
    }
  }
}
