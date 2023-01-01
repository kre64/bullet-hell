using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
  // private int ammo = 0;
  // private int maxAmmo = 0;
  public Text gunTypeText;

  // Start is called before the first frame update
  void Start()
  {
    this.gameObject.SetActive(true);
  }

  public void SetActiveWeapon(string gunType)
  {
    gunTypeText.text = gunType;
    // this.ammo = ammo;
    // this.maxAmmo = maxAmmo;
  }
}
