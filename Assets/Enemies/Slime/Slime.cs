using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
  private GameObject player;

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
  }

  // Update is called once per frame
  void Update()
  {
    MoveToPlayer();
  }

  private void MoveToPlayer()
  {
    if (player != null)
    {
      transform.position = Vector2.MoveTowards(transform.position, player.transform.position, this.moveSpeed * Time.deltaTime);
    }
  }

  private void OnTriggerEnter2D(Collider2D collider)
  {
    if (collider.CompareTag("Player") && collider.GetComponent<Health>() != null)
    {
      collider.GetComponent<Health>().Damage(this.damage);
    }
  }
}
