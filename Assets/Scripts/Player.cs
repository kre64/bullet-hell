using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  public float moveSpeed = 3f;
  public Rigidbody2D rb;

  private GameObject attackArea;
  private Vector2 moveDirection;
  private bool facingRight = true;
  private bool attacking = false;
  private float attackSpeed = 0.25f;
  private float attackTimer = 0f;

  // Start is called before the first frame update
  void Start()
  {
    attackArea = transform.GetChild(0).gameObject;
  }

  // Update is called once per frame
  private void Update()
  {
    if (attacking)
    {
      attackTimer += Time.deltaTime;

      if (attackTimer >= attackSpeed)
      {
        attacking = false;
        attackArea.SetActive(attacking);
        attackTimer = 0f;
      }
    }
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

  private void Attack()
  {
    attacking = true;
    attackArea.SetActive(attacking);
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

  private void OnFire()
  {
    Attack();
  }

  private void OnMove(InputValue value)
  {

    moveDirection = value.Get<Vector2>();
  }
}
