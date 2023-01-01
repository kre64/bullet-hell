using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitching : MonoBehaviour
{
  public static readonly string[] WEAPON_SCRIPTS = new string[] { "Pistol", "Shotgun", "Lasergun" };
  public GameObject weaponHolder;
  public int selectedWeapon = 0;

  // Start is called before the first frame update
  void Start()
  {
    SelectWeapon();
  }

  private void OnScrollWeapon(InputValue value)
  {
    Vector2 scrollDirection = value.Get<Vector2>();
    int previousWeapon = selectedWeapon;

    if (scrollDirection.y > 0f)
    {
      if (selectedWeapon >= weaponHolder.transform.childCount - 1)
      {
        selectedWeapon = 0;
      }
      else
      {
        selectedWeapon++;
      }
    }
    else if (scrollDirection.y < 0f)
    {
      if (selectedWeapon <= 0)
      {
        selectedWeapon = weaponHolder.transform.childCount - 1;
      }
      else
      {
        selectedWeapon--;
      }
    }

    if (previousWeapon != selectedWeapon)
    {
      SelectWeapon();
    }
  }

  void SelectWeapon()
  {
    for (int i = 0; i < weaponHolder.transform.childCount; i++)
    {
      if (i == selectedWeapon)
      {
        weaponHolder.transform.GetChild(i).gameObject.SetActive(true);
        (this.gameObject.GetComponent(WEAPON_SCRIPTS[i]) as MonoBehaviour).enabled = true;
      }
      else
      {
        weaponHolder.transform.GetChild(i).gameObject.SetActive(false);
        (this.gameObject.GetComponent(WEAPON_SCRIPTS[i]) as MonoBehaviour).enabled = false;
      }
    }
  }
}
