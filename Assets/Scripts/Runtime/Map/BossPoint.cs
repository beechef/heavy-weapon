using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossPoint : MonoBehaviour
{
    [SerializeField]private GameStateSO _gameStateSo;
    public float distance;
    public Transform player;
    [SerializeField] private UnityEvent DangerEvent;
    private bool isInvokeEvent;

    private void Start()
    {
        isInvokeEvent = false;
    }

    private void Update()
    {
        distance = Vector2.Distance(player.position, transform.position);
        if (_gameStateSo.State != GameStateSO.GameState.BossFight)
        {
            CheckPlayerPosition(distance);
        }
        
    }

    private void CheckPlayerPosition(float distance)
    {
        if (distance <= 10&&!isInvokeEvent)
        {
            DangerEvent.Invoke();
            isInvokeEvent = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerHolder"))
        {
            _gameStateSo.BossFight();
        }
    }
}
