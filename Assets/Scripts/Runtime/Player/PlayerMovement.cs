using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameStateSO GameState;
    [SerializeField] private BoolVariable isMoveRight;
    private float _constantMoveSpeed = 0.5f;
    [SerializeField] private Animator animator;
    [SerializeField]private FloatVarible moveDirXValue;
    [SerializeField] private BoolVariable canGetInput;
    private void Start()
    {
        isMoveRight.value = true;
        animator.SetFloat("MoveDir",1);
    }
    void Update()
    {
        if (GameState.State == GameStateSO.GameState.StartGame)
        {
            OnGameStart();
        }
        if (canGetInput.value)
        {
            moveDirXValue.value = Input.GetAxis("Horizontal");
        }
        Move(moveDirXValue.value);
    }
    private void Move(float moveSpeed)

    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        float MoveRightVal=1;
        if (!isMoveRight.value)
        {
            _constantMoveSpeed = 0;
        }
        else
        {
            _constantMoveSpeed = 0.5f;
        }

        Vector3 force = new Vector3(moveSpeed*10*Time.deltaTime, 0,0);
        if (moveSpeed < 0)
        {
            MoveRightVal = moveSpeed;
        }
        
        if (pos.x < 0.1f &&moveSpeed<0|| pos.x > 0.9f&&moveSpeed>0)
        {
            force = Vector3.zero;
        }
        
        transform.localPosition += force;

        animator.SetFloat("MoveDir",moveSpeed+(_constantMoveSpeed*MoveRightVal));
    }
    public void OnGameStart()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x >= 0.5f && pos.x <= 0.51f)
        {
            moveDirXValue.value = 0;
            StartCoroutine(WaitToEnterPlayGameState(1.5f));
        }
    }

    IEnumerator WaitToEnterPlayGameState(float time)
    {
        yield return new WaitForSeconds(time);
        GameState.PlayGame();
    }
}
