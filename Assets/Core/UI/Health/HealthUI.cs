using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
  public GameObject heartPrefab;
  public GameObject playerObject;

  private Health playerHealth;
  private List<HealthHeartUI> hearts = new List<HealthHeartUI>();

  void Awake()
  {
    playerHealth = playerObject.GetComponent<Health>();
  }

  void Start()
  {
    RenderHearts();
  }

  void OnEnable()
  {
    Health.OnPlayerDamaged += RenderHearts;
  }

  void OnDisable()
  {
    Health.OnPlayerDamaged -= RenderHearts;
  }

  public void RenderHearts()
  {
    ClearHearts();

    float maxHealthRemainder = playerHealth.GetMaxHealth() % 2;
    int heartsToMake = (int)((playerHealth.GetMaxHealth() / 2) + maxHealthRemainder);

    for (int i = 0; i < heartsToMake; i++)
    {
      CreateEmptyHeart();
    }

    for (int i = 0; i < hearts.Count; i++)
    {
      // hp = 4
      // 0
      // 2
      // 4
      // 6

      int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.GetHealth() - (i * 2), 0, 2);
      hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
    }
  }

  public void CreateEmptyHeart()
  {
    GameObject newHeart = Instantiate(heartPrefab, transform);
    HealthHeartUI heartUI = newHeart.GetComponent<HealthHeartUI>();
    heartUI.SetHeartImage(HeartStatus.Empty);
    hearts.Add(heartUI);
  }

  public void ClearHearts()
  {
    foreach (Transform heart in transform)
    {
      Destroy(heart.gameObject);
    }
    hearts.Clear();
  }

}
