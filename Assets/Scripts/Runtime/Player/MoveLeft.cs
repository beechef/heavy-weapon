using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class MoveLeft : MonoBehaviour
{
   [SerializeField] private Transform bosssPoint;
   [FormerlySerializedAs("moveRightSpeed")] [SerializeField] private FloatVarible moveLeftSpeed;

   [SerializeField] private GameStateSO gameState;

   private void Start()
   {
      gameState.StartGame();
      transform.position = Vector2.zero;
      moveLeftSpeed.value = 0;
   }
   private void Update()
   {
      transform.Translate(-moveLeftSpeed.value*Time.deltaTime*Vector2.right);
   }
  
}
