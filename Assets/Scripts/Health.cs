using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  public int health = 100;

  private int MAX_HEALTH = 100;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SetHealth(int maxHealth, int health)
  {
    this.MAX_HEALTH = maxHealth;
    this.health = health;
  }

  private IEnumerator VisualIndicator(Color color)
  {
    GetComponent<SpriteRenderer>().color = color;
    yield return new WaitForSeconds(0.15f);
    GetComponent<SpriteRenderer>().color = Color.white;
  }

  public void Damage(int damageAmount)
  {
    if (damageAmount < 0)
    {
      throw new System.ArgumentOutOfRangeException("Damage amount cannot be negative");

    }

    StartCoroutine(VisualIndicator(Color.red));

    this.health -= damageAmount;

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

  private void Die()
  {
    Debug.Log("Dead");
    Destroy(gameObject);
  }
}
