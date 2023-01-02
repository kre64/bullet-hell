using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : ProjectileWeapon
{
  void OnEnable()
  {
    gameUI.SetActiveWeapon(WeaponType.Pistol, currentAmmo, maxAmmo);
  }
}
