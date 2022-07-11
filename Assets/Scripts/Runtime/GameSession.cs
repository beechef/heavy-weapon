using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSession : MonoBehaviour
{
    [SerializeField] private BoolVariable isMoveRight;
    [SerializeField] private FloatVarible moveRightSpeed;
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
        moveRightSpeed.value = 0f;
        tankMoveSpeed.value = 1f;
 
    }

    void OnGamePlay()
    {
        canGetInput.value = true;
        isMoveRight.value = true;
        moveRightSpeed.value = 1;
      
    }

    void OnBossFight()
    {
        canGetInput.value = true;
        isMoveRight.value = false;
        moveRightSpeed.value = 0;
    }

    void OnFinishGame()
    {
        canGetInput.value = false;
        isMoveRight.value = true;
        moveRightSpeed.value = 2f;
        tankMoveSpeed.value = 1.5f;

    }

    void OnGameOver()
    {
        canGetInput.value = false;
        isMoveRight.value = false;
        moveRightSpeed.value = 0;
        tankMoveSpeed.value = 0;
    }
    
}
