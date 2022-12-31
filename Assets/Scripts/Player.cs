using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  public float moveSpeed = 3f;
  public Rigidbody2D rb;
  public Camera mainCamera;

  private Vector2 moveDirection;
  private bool facingRight = true;
  private Vector3 mousePosition;
  private GameObject activeGun;

  // Start is called before the first frame update
  void Start()
  {
    activeGun = transform.GetChild(0).gameObject;
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
    mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    Vector3 rotation = mousePosition - activeGun.transform.position;

    float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    
    activeGun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
  }
}
