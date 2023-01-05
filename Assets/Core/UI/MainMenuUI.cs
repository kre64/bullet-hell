using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
  void Start()
  {
    Time.timeScale = 1;
  }

  public void StartGameButton()
  {
    GameManager.instance.UpdateGameState(GameState.InGame);
  }

  public void ExitGameButton()
  {
    Application.Quit();
  }
}
