using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameStateSO State;

    private void Start()
    {
        State.lives = 3;
    }

    void Update()
    {
        State.UpdateState();
    }
}
