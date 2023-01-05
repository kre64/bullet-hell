using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
  public Text scoreValueText;

  private int score = 0;

  void Awake()
  {
    Health.OnEnemyDeath += CountScore;
    GameManager.OnGameOver += HandleGameOver;
    this.gameObject.SetActive(false);
  }

  void OnDestroy()
  {
    Health.OnEnemyDeath -= CountScore;
    GameManager.OnGameOver -= HandleGameOver;
  }

  public void ReturnToMenu()
  {
    GameManager.instance.UpdateGameState(GameState.MainMenu);
  }

  private void CountScore()
  {
    score++;
  }

  private void HandleGameOver()
  {
    this.gameObject.SetActive(true);
    scoreValueText.text = score.ToString();
  }
}
