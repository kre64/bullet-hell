using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
  public static Action OnPlayerDeath;
  public static Action OnEnemyDeath;

  private int health = 100;
  private int MAX_HEALTH = 100;

  public void SetHealth(int maxHealth, int health)
  {
    this.MAX_HEALTH = maxHealth;
    this.health = health;
    Debug.Log(this.health);
  }

  public void Damage(int damageAmount)
  {
    if (damageAmount < 0)
    {
      throw new System.ArgumentOutOfRangeException("Damage amount cannot be negative");
    }

    StartCoroutine(VisualIndicator(Color.red));

    this.health -= damageAmount;
    Debug.Log(this.health);

    if (health <= 0)
    {
      Die();
    }
  }

  public void Heal(int healAmount)
  {
    if (healAmount < 0)
    {
      throw new System.ArgumentOutOfRangeException("Heal amount cannot be negative");
    }

    bool isOverHeal = health + healAmount > MAX_HEALTH;

    StartCoroutine(VisualIndicator(Color.red));

    if (isOverHeal)
    {
      this.health = MAX_HEALTH;
    }

    this.health += healAmount;
  }

  private IEnumerator VisualIndicator(Color color)
  {
    GetComponent<SpriteRenderer>().color = color;
    yield return new WaitForSeconds(0.15f);
    GetComponent<SpriteRenderer>().color = Color.white;
  }

  private void Die()
  {
    if (this.CompareTag("Player"))
    {
      Time.timeScale = 0;
      OnPlayerDeath?.Invoke();
    }
    else
    {
      OnEnemyDeath?.Invoke();
    }

    Destroy(gameObject);
  }
}
