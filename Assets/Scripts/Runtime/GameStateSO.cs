using Runtime;
using UnityEngine;

[CreateAssetMenu]
public class GameStateSO : ScriptableObject
{
    public bool isMoveRight;
    public float moveLeftSpeed;
    public float tankMoveSpeed;
    public bool canGetInput;
    public GameState State;
    public int ingameLives;

    [SerializeField] private IntVariable pointsRemaining;
    [SerializeField] private IntVariable inGameScores;
    [SerializeField] private IntVariable totalScores;

    public enum GameState
    {
        StartGame,
        PlayGame,
        PlayerDead,
        BossKilled,
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

    public void BossKilled()
    {
        State = GameState.BossKilled;
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

    public void PlayerDead()
    {
        State = GameState.PlayerDead;
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
            case GameState.BossKilled:
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
            case GameState.PlayerDead:
                OnPlayerDead();
                break;
            default:
                OnGameOver();
                break;
        }
    }

    void OnPlayerDead()
    {
        canGetInput = false;
        isMoveRight = false;
    }
    void OnGameStart()
    {
    
        canGetInput = false;
        isMoveRight = true;
        moveLeftSpeed = 1f;
        tankMoveSpeed = 0.5f;
        inGameScores.Value = 0;
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

    private void OnRevive()
    {
        canGetInput = false;
        isMoveRight = true;
    }

    public void OnFinishLevel()
    {
        canGetInput = false;
        isMoveRight = false;
        moveLeftSpeed = 0;
        tankMoveSpeed = 0f;
        pointsRemaining.Value++;
        totalScores.Value += inGameScores.Value;
    }
}