using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
   [SerializeField] private float moveRightSpeed;
   
   private void Update()
   {
      
      transform.Translate(moveRightSpeed*Time.deltaTime*Vector2.right);
   }
   private void OnTriggerEnter2D(Collider2D col)
   {
      if (col.CompareTag("BossPoint"))
      {
         moveRightSpeed = 0;
      }
   }
}
