using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RaycastWeaponData", order = 1)]
public class RaycastWeaponData : ScriptableObject
{
  public int damage;
  public float heatPerShot;
  public float heatCooldownRate;
  public float maxDistance;
  public float knockbackForce;
  public float knockbackDelay;
}