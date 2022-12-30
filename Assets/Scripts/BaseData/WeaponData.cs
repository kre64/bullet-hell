using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]

public class WeaponData : ScriptableObject
{
  public int damage;
  public float knockbackForce;
  public float knockbackDelay;
  public float attackDelay;
}
