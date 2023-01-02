using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RaycastWeaponData", order = 1)]
public class RaycastWeaponData : ScriptableObject
{
  public int damage;
  public int heatPerShot;
  public int maxHeat;
  public int heatDecrement;
  public float heatDecrementTime;
  public float maxDistance;
  public float knockbackForce;
  public float knockbackDelay;
}