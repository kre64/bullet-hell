using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  public float moveSpeed = 3f;
  public Rigidbody2D rb;

  private Vector2 moveDirection;
  private bool facingRight = true;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  private void Update()
  {
    
  }

  private void FixedUpdate()
  {
    CheckForFlip();
    Move();
  }

  private void Move()
  {
    rb.velocity = moveDirection.normalized * moveSpeed;
  }

  private void CheckForFlip()
  {
    bool movingLeft = moveDirection.x < 0;
    bool movingRight = moveDirection.x > 0;

    if (movingLeft && facingRight)
    {
      transform.Rotate(0f, 180f, 0f);
      facingRight = false;
    }
    else if (movingRight && !facingRight)
    {
      transform.Rotate(0f, 180f, 0f);
      facingRight = true;
    }
  }

  private void OnMove(InputValue value)
  {
    moveDirection = value.Get<Vector2>();
  }
}
