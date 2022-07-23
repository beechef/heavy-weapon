using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class IngameUIManager : MonoBehaviour
{
   [SerializeField] private GameObject gameOver;
   [SerializeField] private GameObject victory;
   [SerializeField] private UnityEvent gameOverEvent;
   [SerializeField] private GameStateSO GameState;
   private bool isInvokeEvent;
    void Start()
    {
        isInvokeEvent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.State == GameStateSO.GameState.GameOver)
        {
            if (!isInvokeEvent)
            {
                gameOverEvent.Invoke();
                isInvokeEvent = true;
            }
            gameOver.SetActive(true);
        }
    }
}
