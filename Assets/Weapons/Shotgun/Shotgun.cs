using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : ProjectileWeapon
{
  void OnEnable()
  {
    gunUI.SetActiveWeapon(WeaponType.Shotgun, currentAmmo, maxAmmo);
  }
}
