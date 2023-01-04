using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  public PlayerData playerData;
  public Rigidbody2D rb;
  public Camera mainCamera;
  public GameObject weaponHolder;

  private int hp;
  private int maxHp;
  private float moveSpeed;
  private Vector2 moveDirection;
  private bool facingRight = true;
  private Vector3 mousePosition;
  private GameObject activeGun;

  void Awake()
  {
    InitPlayer(playerData);
  }

  // Update is called once per frame
  private void Update()
  {

  }

  private void FixedUpdate()
  {
    // TODO: Evaluate calls here for perf optimi
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

  protected void InitPlayer(PlayerData playerData)
  {
    GetComponent<Health>().SetHealth(playerData.hp, playerData.maxHp);
    this.moveSpeed = playerData.moveSpeed;
  }
}
