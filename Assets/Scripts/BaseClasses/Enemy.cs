using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public EnemyData enemyData;
  protected int damage;
  protected float moveSpeed;

  // Start is called before the first frame update
  void Start()
  {
    InitEnemyValues();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void InitEnemyValues()
  {
    GetComponent<Health>().SetHealth(enemyData.hp, enemyData.hp);
    damage = enemyData.damage;
    moveSpeed = enemyData.moveSpeed;
  }
}
