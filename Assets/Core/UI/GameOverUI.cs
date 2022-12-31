using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
  public Text scoreValueText;

  private int score = 0;

  // Start is called before the first frame update
  void Start()
  {
    Health.OnPlayerDeath += ActivateGameObject;
    Health.OnEnemyDeath += CountScore;
    this.gameObject.SetActive(false);
  }

  public void ReturnToMenu()
  {
    SceneManager.LoadScene(0);
  }

  private void OnDestroy()
  {
    Health.OnPlayerDeath -= ActivateGameObject;
    Health.OnEnemyDeath -= CountScore;
  }

  private void CountScore()
  {
    score++;
  }

  private void ActivateGameObject()
  {
    this.gameObject.SetActive(true);
    scoreValueText.text = score.ToString();
  }
}
