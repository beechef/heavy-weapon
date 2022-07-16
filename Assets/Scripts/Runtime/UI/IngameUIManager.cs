using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngameUIManager : MonoBehaviour
{
   [SerializeField] private GameObject gameOver;
   [SerializeField] private GameObject victory;
   
   [SerializeField] private GameStateSO GameState;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.State == GameStateSO.GameState.GameOver)
        {
            gameOver.SetActive(true);
        }
    }
}
