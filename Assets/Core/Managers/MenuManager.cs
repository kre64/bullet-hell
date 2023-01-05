using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  void Awake()
  {
    GameManager.OnGameStateChange += HandleGameStateChange;
  }

  void OnDestroy()
  {
    GameManager.OnGameStateChange -= HandleGameStateChange;
  }

  private void HandleGameStateChange(GameState newState)
  {
    switch (newState)
    {
      case GameState.MainMenu:
        SceneManager.LoadScene((int)Scenes.MainMenu);
        break;
      case GameState.InGame:
        SceneManager.LoadScene((int)Scenes.Game);
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
    }
  }
}
