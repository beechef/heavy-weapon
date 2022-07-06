using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveDir;
    private CharacterController _playerController;
    public float speed=10f;
    void Start()
    {
        _playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveDir = new Vector2(Input.GetAxis("Horizontal"),0);
        _playerController.Move(_moveDir * Time.deltaTime * speed);
    }
}
