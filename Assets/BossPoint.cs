using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPoint : MonoBehaviour
{
    [SerializeField]private GameStateSO _gameStateSo;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerHolder"))
        {
            _gameStateSo.BossFight();
        }
    }
}
