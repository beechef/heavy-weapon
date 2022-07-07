using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float speed=10f;
    public bool isMoveRight;
    private float constantMoveSpeed = 0.5f;
    [SerializeField] private Animator animator;
    private float moveDirXValue;
    
    private void Start()
    {
        isMoveRight = true;
        animator.SetBool("isMoveRight",true);
        animator.SetFloat("MoveDir",1);
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        float MoveRightVal=1;
        if (!isMoveRight)
        {
            constantMoveSpeed = 0;
        }
        else
        {
            constantMoveSpeed = 0.5f;
        }
        moveDirXValue = Input.GetAxis("Horizontal");
        
        Vector3 force = new Vector3(moveDirXValue*speed*Time.deltaTime, 0,0);
        if (moveDirXValue < 0)
        {
            MoveRightVal = moveDirXValue;
        }
        
        if (pos.x < 0.1f &&moveDirXValue<0|| pos.x > 0.9f&&moveDirXValue>0)
        {
            force = Vector3.zero;
        }
        transform.localPosition =transform.localPosition + force;

        animator.SetFloat("MoveDir",moveDirXValue+(constantMoveSpeed*MoveRightVal));
        
    }
}
