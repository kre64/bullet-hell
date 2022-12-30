using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public EnemyData enemyData;
  public int damage = 5;
  public float moveSpeed = 1.5f;

  // Start is called before the first frame update
  void Start()
  {
    InitEnemyValues();
  }

  // Update is called once per frame
  void Update()
  {
    // MoveToPlayer();
  }

  private void InitEnemyValues()
  {
    GetComponent<Health>().SetHealth(enemyData.hp, enemyData.hp);
    damage = enemyData.damage;
    moveSpeed = enemyData.moveSpeed;
  }

  // private void MoveToPlayer()
  // {
  //   if (player != null)
  //   {
  //     transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
  //   }
  // }

  // private void OnTriggerEnter2D(Collider2D collider)
  // {
  //   if (collider.CompareTag("Player") && collider.GetComponent<Health>() != null)
  //   {
  //     collider.GetComponent<Health>().Damage(damage);
  //   }
  // }
}
