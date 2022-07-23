using System.Collections;
using System.Collections.Generic;
using Runtime;
using UnityEngine;

public class NewGAmePress : MonoBehaviour
{
    [SerializeField] public IntVariable pointsRemaining;
    [SerializeField] public IntVariable currentMission;
    [SerializeField] public IntVariable inGameScores;
    [SerializeField] public IntVariable totalScores;

    public void NewGame()
    {
        pointsRemaining.Value = 0;
        currentMission.Value = 0;
        inGameScores.Value = 0;
        totalScores.Value = 0;
    }
}
