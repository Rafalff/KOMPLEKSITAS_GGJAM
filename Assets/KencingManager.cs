using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    WAIT, GAMEPLAY, GAMEOVER
}

public class KencingManager : MonoBehaviour
{
    public static KencingManager instance;
    //public PlayerController playerController;

    public GameState state;
    public static event Action<GameState> OnGameStateChanged;
    public float delayBeforeStart;
    public float kencingTimer;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.WAIT);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.WAIT:
                break;

            case GameState.GAMEPLAY:
                break;

            case GameState.GAMEOVER:
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }
}
