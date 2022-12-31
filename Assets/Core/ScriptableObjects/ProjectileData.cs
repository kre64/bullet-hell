using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ProjectileData", order = 1)]
public class ProjectileData : ScriptableObject
{
  public int damage;
  public float speed;
  public float knockbackForce;
  public float knockbackDelay;
}