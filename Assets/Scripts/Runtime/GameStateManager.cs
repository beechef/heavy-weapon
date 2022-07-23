using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameStateSO State;

    public void FinishMissionUpdate()
    {
        State.pointsRemaining.Value++;
        State.totalScores.Value += State.inGameScores.Value;
        State.currentMission.Value += 1;
    }

    private void Start()
    {
        State.StartGame();
    }

    void Update()
    {
        State.UpdateState();
    }
}
