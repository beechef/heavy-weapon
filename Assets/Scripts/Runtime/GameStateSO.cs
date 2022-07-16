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
    [SerializeField] private UnityEvent playerDead;

    public enum GameState
    {
        StartGame,
        PlayGame,
        EndGame,
        GameOver,
        BossFight,
        Revive,
        FinishMission
    }

    public void StartGame()
    {
        State = GameState.StartGame;
    }
    public void Revive()
    {
        State = GameState.Revive;
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

    public void FinishMission()
    {
        State = GameState.FinishMission;
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
                OnBossKilled();
                break;
            case GameState.GameOver:
                OnGameOver();
                break;
            case GameState.Revive:
                OnRevive();
                break;
            case GameState.FinishMission:
                OnFinishLevel();
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

    void OnBossKilled()
    {
        canGetInput = false;
        isMoveRight = true;
        moveLeftSpeed = 1.2f;
        tankMoveSpeed = 0;
    }

    void OnGameOver()
    {
        canGetInput = false;
        isMoveRight = false;
        moveLeftSpeed = 0;
        tankMoveSpeed = 0;
    }
    public void OnPlayerDead()
    {
        if(lives<=0)
        {
            GameOver();                                                                         
        }
        lives -= 1;
    }

    private void OnRevive()
    {
        canGetInput = false;
        isMoveRight = true;
        tankMoveSpeed = 0.5f;
    }

    public void OnFinishLevel()
    {
        canGetInput = false;
        isMoveRight = false;
        moveLeftSpeed = 0;
        tankMoveSpeed = 0f;
    }
}