using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameSession : MonoBehaviour
{
    [SerializeField] private BoolVariable isMoveRight;
    [SerializeField] private FloatVarible moveLeftSpeed;
    [SerializeField] private FloatVarible tankMoveSpeed;
    [SerializeField] private GameStateSO gameStateSo;
    [SerializeField] private BoolVariable canGetInput;
    
    private void Update()
    {
        switch (gameStateSo.State)
        {
            case GameStateSO.GameState.StartGame:
                OnGameStart();
                break;
            case GameStateSO.GameState.PlayGame:
                OnGamePlay();
                break;
            case GameStateSO.GameState.BossFight:
                OnBossFight();
                break;
            case GameStateSO.GameState.EndGame:
                OnFinishGame();
                break;
            case GameStateSO.GameState.GameOver:
                OnGameOver();
                break;
            default:
                OnGameOver();
                break;
        }
    }

    void OnGameStart()
    {
        canGetInput.value = false;
        isMoveRight.value = false;
        moveLeftSpeed.value = 0f;
        tankMoveSpeed.value = 1f;
 
    }

    void OnGamePlay()
    {
        canGetInput.value = true;
        isMoveRight.value = true;
        moveLeftSpeed.value = 1;
      
    }

    void OnBossFight()
    {
        canGetInput.value = true;
        isMoveRight.value = false;
        moveLeftSpeed.value = 0;
    }

    void OnFinishGame()
    {
        canGetInput.value = false;
        isMoveRight.value = true;
        moveLeftSpeed.value = 2f;
        tankMoveSpeed.value = 1.5f;

    }

    void OnGameOver()
    {
        canGetInput.value = false;
        isMoveRight.value = false;
        moveLeftSpeed.value = 0;
        tankMoveSpeed.value = 0;
    }
    
}
