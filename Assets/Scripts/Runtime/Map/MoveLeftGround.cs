using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class MoveLeftGround : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] GameStateSO state;
    private SpriteRenderer sprite;
    

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
       
        if (transform.position.x < -(5.3+sprite.bounds.size.x/2))
        {
            transform.position = transform.parent.position;
        } 
        transform.position += new Vector3(-moveSpeed*state.moveLeftSpeed * Time.deltaTime, 0);
    }
    
}
