using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : ProjectileWeapon
{
  void OnEnable()
  {
    gameUI.SetActiveWeapon(WeaponType.Shotgun, currentAmmo, maxAmmo);
  }
}
