using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveDir;
    private CharacterController _playerController;
    public float speed=10f;
    public bool isMoveRight;
    private float constantMoveSpeed = 0.5f;
    [SerializeField] private Animator animator;
    private void Start()
    {
        isMoveRight = true;
        _playerController = GetComponent<CharacterController>();
        animator.SetBool("isMoveRight",true);
        animator.SetFloat("MoveDir",1);
    }

    // Update is called once per frame
    void Update()
    {
      Move();
    }

    private void Move()
    {
        float MoveRightVal=1;
        
        if (!isMoveRight)
        {
            constantMoveSpeed = 0;
        }
        else
        {
            constantMoveSpeed = 0.5f;
        }
        float moveDirXValue = Input.GetAxis("Horizontal");
        if (moveDirXValue < 0)
        {
            MoveRightVal = moveDirXValue;
        }
        _moveDir = new Vector2(moveDirXValue,0);
        animator.SetFloat("MoveDir",moveDirXValue+(constantMoveSpeed*MoveRightVal));
        _playerController.Move(_moveDir * (Time.deltaTime * speed));
    }
}
