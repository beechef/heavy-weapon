using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameStateSO State;

    private void Start()
    {
        State.StartGame();
    }

    void Update()
    {
        State.UpdateState();
    }
}
