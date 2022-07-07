using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
   [SerializeField] private float moveRightSpeed;
   private PlayerMovement _playerMovement;

   private void Start()
   {
      _playerMovement = GetComponent<PlayerMovement>();
   }

   private void Update()
   {
      transform.Translate(moveRightSpeed*Time.deltaTime*Vector2.right);
   }
}
