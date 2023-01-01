using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  public Rigidbody2D rb;
  public Camera mainCamera;
  public GameObject weaponHolder;

  private int hp = 100;
  private int maxHp = 100;
  private float moveSpeed = 3f;
  private Vector2 moveDirection;
  private bool facingRight = true;
  private Vector3 mousePosition;
  private GameObject activeGun;

  // Start is called before the first frame update
  void Start()
  {
    InitPlayer();
  }

  // Update is called once per frame
  private void Update()
  {

  }

  private void FixedUpdate()
  {
    AimAtMouse();
    CheckForFlip();
    Move();
  }

  private void Move()
  {
    rb.velocity = moveDirection.normalized * moveSpeed;
  }

  private void CheckForFlip()
  {
    Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    bool movingLeft = moveDirection.x < 0;
    bool movingRight = moveDirection.x > 0;

    if (mousePosition.x < transform.position.x && facingRight)
    {
      transform.Rotate(0f, 180f, 0f);
      facingRight = false;
    }
    else if (mousePosition.x > transform.position.x && !facingRight)
    {
      transform.Rotate(0f, 180f, 0f);
      facingRight = true;
    }
  }

  private void OnMove(InputValue value)
  {
    moveDirection = value.Get<Vector2>();
  }

  private void AimAtMouse()
  {
    int selectedWeaponIndex = transform.GetComponent<WeaponSwitching>().selectedWeapon;
    activeGun = weaponHolder.transform.GetChild(selectedWeaponIndex).gameObject;
    mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

    Vector3 rotation = mousePosition - activeGun.transform.position;
    float weaponRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

    if (!facingRight)
    {
      activeGun.transform.rotation = Quaternion.Euler(180f, 0f, -weaponRotation);
    }
    else
    {
      activeGun.transform.rotation = Quaternion.Euler(0f, 0f, weaponRotation);
    }
  }

  protected void InitPlayer()
  {
    GetComponent<Health>().SetHealth(hp, maxHp);
  }
}
