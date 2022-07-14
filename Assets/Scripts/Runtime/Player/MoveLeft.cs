using UnityEngine;
using UnityEngine.Serialization;

public class MoveLeft : MonoBehaviour
{
   [SerializeField] private Transform bosssPoint;

   [SerializeField] private GameStateSO gameState;

   private void Start()
   {
      gameState.StartGame();
      transform.position = Vector2.zero;
      gameState.moveLeftSpeed = 0;
   }
   private void Update()
   {
      transform.Translate(-gameState.moveLeftSpeed*Time.deltaTime*Vector2.right);
   }
  
}
