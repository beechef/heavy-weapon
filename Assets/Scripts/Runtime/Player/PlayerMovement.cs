using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameStateSO GameState;
    private float _constantMoveSpeed = 0.5f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer tankMesh;
    [SerializeField] private GameObject tankBarrel;
    public Vector2 startPos;
    [SerializeField] private UnityEvent playerRevive;
    private bool isReviveEventInvoke;
    private Vector3 pos;

    private void Start()
    {
        isReviveEventInvoke = false;
            startPos = transform.position;
        GameState.isMoveRight = true;
        animator.SetFloat("MoveDir",1);
    }
    void Update()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);
        if (GameState.State == GameStateSO.GameState.StartGame)
        {
            OnGameStart();
        }

        if (GameState.State == GameStateSO.GameState.Revive)
        {
            CheckEventInvoke();
        }
        if (GameState.canGetInput)
        {
            GameState.tankMoveSpeed = Input.GetAxis("Horizontal");
        }
        Move(GameState.tankMoveSpeed);
    }
    private void Move(float moveSpeed)

    {
      
        float MoveRightVal=1;
        if (!GameState.isMoveRight)
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
        if (pos.x >= 0.5f )
        {
            GameState.tankMoveSpeed = 0;
            StartCoroutine(WaitToEnterPlayGameState(1.5f));
        }
    }
    IEnumerator WaitToEnterPlayGameState(float time)
    {
        yield return new WaitForSeconds(time);
        GameState.PlayGame();
    }
    
    public void Revieve()
    {
        isReviveEventInvoke = true;
        tankMesh.enabled = true;
        tankBarrel.SetActive(true);
        GameState.tankMoveSpeed =0.5f;
        if (pos.x >= 0.5f &&GameState.State ==GameStateSO.GameState.Revive)
        {
            GameState.tankMoveSpeed = 0;
            isReviveEventInvoke = false;
            if (GameState.moveLeftSpeed > 0)
            {
                GameState.PlayGame();
            }
            else
            {
                GameState.BossFight();
            }
            
        }
    }
    private void CheckEventInvoke()
    {
        if (isReviveEventInvoke)
        {
            return;
        }
        playerRevive.Invoke();
    }
    }

