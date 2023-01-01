using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
  public int damage;
  public float maxDistance;
  public float knockbackForce;
  public float knockbackDelay;
}