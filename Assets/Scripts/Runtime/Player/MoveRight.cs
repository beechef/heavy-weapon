using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveRight : MonoBehaviour
{
   [SerializeField] private FloatVarible moveRightSpeed;

   [SerializeField] private GameStateSO gameState;

   private void Start()
   {
      gameState.StartGame();
      transform.position = Vector2.zero;
      moveRightSpeed.value = 0;
   }
   private void Update()
   {
      transform.Translate(moveRightSpeed.value*Time.deltaTime*Vector2.right);
   }
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("BossPoint"))
      {
         gameState.BossFight();
      }
   }
}
