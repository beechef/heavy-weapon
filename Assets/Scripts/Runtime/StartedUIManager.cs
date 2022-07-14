using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartedUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameStateSO gameStateSo;
    
    private void Start()
    {
        text.enabled = false;
    }
    void OnGameStart()
    {
        //prepareAudio.Play();
        text.enabled = true;
    }
    void OnGamePlay()
    {
        text.enabled = false;
    }
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
                //OnBossFight();
                break;
            case GameStateSO.GameState.EndGame:
                //OnFinishGame();
                break;
            case GameStateSO.GameState.GameOver:
                //OnGameOver();
                break;
            default:
                //OnGameOver();
                break;
        }
    }
}