using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GameStateSO : ScriptableObject
{
    public GameState State;
  
    public enum GameState
    {
        StartGame,
        PlayGame,
        EndGame,
        GameOver,
        BossFight
    }
    public void StartGame()
    {
        State = GameStateSO.GameState.StartGame;
    }

    public void EndGame()
    {
        State = GameStateSO.GameState.EndGame;
    }
    public void PlayGame()
    {
        State = GameStateSO.GameState.PlayGame;
    }
    public void GameOver()
    {
        State = GameStateSO.GameState.GameOver;
    }
    public void BossFight()
    {
        State = GameStateSO.GameState.BossFight;
    }
}
