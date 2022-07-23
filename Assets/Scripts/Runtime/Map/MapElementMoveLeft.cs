using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapElementMoveLeft : MonoBehaviour
{
    [SerializeField] private GameStateSO state;
       public float moveSpeed;
       private void Update()
       {
           transform.position += new Vector3(-moveSpeed*state.moveLeftSpeed * Time.deltaTime, 0);
       }
}
