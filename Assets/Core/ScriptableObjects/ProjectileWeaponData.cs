using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ProjectileWeaponData", order = 1)]
public class ProjectileWeaponData : ScriptableObject
{
  public int damage;
  public int ammo;
  public int maxAmmo;
  public float maxDistance;
  public float knockbackForce;
  public float knockbackDelay;
}