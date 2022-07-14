using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class GameStateSO : ScriptableObject
{
    public bool isMoveRight;
    public float moveLeftSpeed;
    public float tankMoveSpeed;
    public bool canGetInput;
    public int lives;
    public GameState State;

    public enum GameState
    {
        StartGame,
        PlayGame,
        EndGame,
        GameOver,
        BossFight,
        Dead
    }

    public void StartGame()
    {
        State = GameState.StartGame;
    }

    public void EndGame()
    {
        State = GameState.EndGame;
    }

    public void PlayGame()
    {
        State = GameState.PlayGame;
    }

    public void GameOver()
    {
        State = GameState.GameOver;
    }

    public void BossFight()
    {
        State = GameState.BossFight;
    }

    public void Dead()
    {
        State = GameState.Dead;
    }

    public void UpdateState()
    {
        switch (State)
        {
            case GameState.StartGame:
                OnGameStart();
                break;
            case GameState.PlayGame:
                OnGamePlay();
                break;
            case GameState.BossFight:
                OnBossFight();
                break;
            case GameState.EndGame:
                OnFinishGame();
                break;
            case GameState.GameOver:
                OnGameOver();
                break;
            case GameState.Dead:
                OnPlayerDead();
                break;
            default:
                OnGameOver();
                break;
        }
    }

    void OnGameStart()
    {
        lives = 3;
        canGetInput = false;
        isMoveRight = true;
        moveLeftSpeed = 1f;
        tankMoveSpeed = 0.5f;
    }

    void OnGamePlay()
    {
        canGetInput = true;
        isMoveRight = true;
        moveLeftSpeed = 1;
    }

    void OnBossFight()
    {
        canGetInput = true;
        isMoveRight = false;
        moveLeftSpeed = 0;
    }

    void OnFinishGame()
    {
        canGetInput = false;
        isMoveRight = true;
        moveLeftSpeed = 2f;
        tankMoveSpeed = 1.5f;
    }

    void OnGameOver()
    {
        canGetInput = false;
        isMoveRight = false;
        moveLeftSpeed = 0;
        tankMoveSpeed = 0;
    }
    void OnPlayerDead()
    {
        if(lives<0)
        {
            GameOver();
        }
        lives -= 1;
        
    }
}