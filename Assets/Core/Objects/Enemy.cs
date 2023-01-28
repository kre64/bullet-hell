using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public EnemyData enemyData;
  
  protected int hp;
  protected int maxHp;
  protected int damage;
  protected float moveSpeed;

  void Awake()
  {
    InitEnemyValues(enemyData);
  }

  // Update is called once per frame
  void Update()
  {

  }

  protected void InitEnemyValues(EnemyData enemyData)
  {
    GetComponent<Health>().SetHealth(enemyData.hp, enemyData.maxHp);
    this.damage = enemyData.damage;
    this.moveSpeed = enemyData.moveSpeed;
  }
}
