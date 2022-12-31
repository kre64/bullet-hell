using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  public Transform firePoint;
  public GameObject projectilePrefab;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnFire()
  {
    Shoot();
  }

  private void Shoot()
  {
    Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
  }
}
