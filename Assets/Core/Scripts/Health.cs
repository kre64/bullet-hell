using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
  public static event Action OnPlayerDamaged;
  public static event Action OnPlayerDeath;
  public static event Action OnEnemyDeath;

  private int hp;
  private int maxHp;

  public int GetHealth()
  {
    return this.hp;
  }

  public int GetMaxHealth()
  {
    return this.maxHp;
  }

  public void SetHealth(int hp, int maxHp)
  {
    this.maxHp = maxHp;
    this.hp = hp;
  }

  public void Damage(int damageAmount)
  {
    if (damageAmount < 0)
    {
      throw new System.ArgumentOutOfRangeException("Damage amount cannot be negative");
    }

    StartCoroutine(VisualIndicator(Color.red));

    this.hp -= damageAmount;

    if (this.CompareTag("Player"))
    {
      // TODO: Add iframes when player is hit
      OnPlayerDamaged?.Invoke();
    }

    if (this.hp <= 0)
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

    bool isOverHeal = this.hp + healAmount > this.maxHp;

    StartCoroutine(VisualIndicator(Color.red));

    if (isOverHeal)
    {
      this.hp = this.maxHp;
    }

    this.hp += healAmount;
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
