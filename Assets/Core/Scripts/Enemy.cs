using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public EnemyData enemyData;
  public int hp;
  public int maxHp;
  public int damage;
  public float moveSpeed;

  // Start is called before the first frame update
  void Start()
  {
    InitEnemyValues();
  }

  // Update is called once per frame
  void Update()
  {

  }

  protected void InitEnemyValues()
  {
    GetComponent<Health>().SetHealth(enemyData.hp, enemyData.maxHp);
  }
}
