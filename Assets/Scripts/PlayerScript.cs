using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
  public float moveSpeed = 3f;
  public InputAction playerControls;
  public Rigidbody2D rb;

  private Vector2 moveDirection;
  private bool facingRight = true;

  private void OnEnable()
  {
    playerControls.Enable();
  }

  private void OnDisable()
  {
    playerControls.Disable();
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  private void Update()
  {
    moveDirection = playerControls.ReadValue<Vector2>();
  }

  private void FixedUpdate()
  {
    CheckForFlip();
    Move();
  }

  private void Move()
  {
    rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed).normalized;
  }

  private void CheckForFlip()
  {
    bool movingLeft = moveDirection.x < 0;
    bool movingRight = moveDirection.x > 0;

    if (movingLeft && facingRight)
    {
      transform.localScale = new Vector3(-1, 1, 1);
      facingRight = false;
    }
    else if (movingRight && !facingRight)
    {
      transform.localScale = new Vector3(1, 1, 1);
      facingRight = true;
    }
  }
}
