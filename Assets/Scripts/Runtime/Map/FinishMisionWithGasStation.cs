using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Enemy;
using UnityEngine;
using UnityEngine.Events;

public class FinishMisionWithGasStation : MonoBehaviour
{
    [SerializeField] private GameStateSO state;
    [SerializeField] private PlayerPosition playerPosition;
    [SerializeField] private UnityEvent finishEnvent;
    private bool isInvokeEvent;

    private void Start()
    {
        isInvokeEvent = false;
    }

    private void Update()
    {
        if (Vector2.Distance(playerPosition.Position, transform.position) < 1.5f)
        {
            if (!isInvokeEvent)
            {
                finishEnvent.Invoke();
                isInvokeEvent = true;
            }
            state.FinishMission();
            Time.timeScale = 0;
        }
    }
}
