using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class MoveLeftGround : MonoBehaviour
{
    public float moveSpeed;
    private SpriteRenderer sprite;
    

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
       
        if (transform.position.x < -(5.3+sprite.bounds.size.x/2))
        {
            Destroy(gameObject);
        } 
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
    }
    
}
