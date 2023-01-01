using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasergun : RaycastWeapon
{
  void OnEnable()
  {
    gameUI.SetActiveWeapon("Lasergun");
  }
}
