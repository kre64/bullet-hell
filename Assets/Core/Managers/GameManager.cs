using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;
  public static event Action<GameState> OnGameStateChange;
  public static event Action OnGameOver;
  public GameState state;

  void Awake()
  {
    if (GameManager.instance != null)
    {
      Destroy(gameObject);
      return;
    }
    instance = this;
    DontDestroyOnLoad(gameObject);
  }

  void Start()
  {
    UpdateGameState(GameState.MainMenu);
  }

  public void UpdateGameState(GameState newState)
  {
    state = newState;

    switch (state)
    {
      case GameState.MainMenu:
        Debug.Log("Main Menu");
        SceneManager.LoadScene((int)Scenes.MainMenu);
        break;
      case GameState.InGame:
        SceneManager.LoadScene((int)Scenes.Game);
        Debug.Log("In Game");
        break;
      case GameState.ExitGame:
        Debug.Log("ExitGame");
        Application.Quit();
        break;
      case GameState.GameOver:
        Debug.Log("GameOver");
        OnGameOver?.Invoke();
        return;
      default:
        throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
    }

    OnGameStateChange?.Invoke(newState);
  }
}
