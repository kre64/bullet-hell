using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
  public int hp;
  public int maxHp;
  public int damage;
  public float moveSpeed;
}