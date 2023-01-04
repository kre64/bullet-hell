using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasergun : RaycastWeapon
{
  void OnEnable()
  {
    gunUI.SetActiveWeapon(WeaponType.Lasergun, heat);
  }
}
