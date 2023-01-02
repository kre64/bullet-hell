using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
  public Text currentAmmo;
  public Text currentHeat;
  public Text maxAmmo;
  public Text currentWeapon;
  public GameObject projectileWeaponUI;
  public GameObject raycastWeaponUI;

  // Start is called before the first frame update
  void Start()
  {
    this.gameObject.SetActive(true);
  }

  // Projectile Weapons
  public void SetActiveWeapon(WeaponType weaponType, int currentAmmo, int maxAmmo)
  {
    SwitchToProjectileWeaponUI();
    this.currentWeapon.text = weaponType.ToString();
    this.currentAmmo.text = currentAmmo.ToString();
    this.maxAmmo.text = maxAmmo.ToString();
  }

  // Raycast Weapons
  public void SetActiveWeapon(WeaponType weaponType, float heatPercentage)
  {
    SwitchToRaycastWeaponUI();
    this.currentWeapon.text = weaponType.ToString();
    this.currentHeat.text = Mathf.Floor(heatPercentage).ToString();
  }

  public void SetCurrentAmmo(int ammo)
  {
    this.currentAmmo.text = ammo.ToString();
  }

  public void SetCurrentHeat(int heat)
  {
    this.currentHeat.text = heat.ToString();
  }

  private void SwitchToProjectileWeaponUI()
  {
    this.raycastWeaponUI.SetActive(false);
    this.projectileWeaponUI.SetActive(true);
  }

  private void SwitchToRaycastWeaponUI()
  {
    this.projectileWeaponUI.SetActive(false);
    this.raycastWeaponUI.SetActive(true);
  }
}
