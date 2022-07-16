using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameStateSO State;
    [SerializeField] private TextMeshProUGUI readyText;
    

    void Update()
    {
        State.UpdateState();
    }
}
