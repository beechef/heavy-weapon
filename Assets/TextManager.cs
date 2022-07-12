using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
  [SerializeField] private GameStateSO State;
  [SerializeField] private float enableTime;
  [SerializeField] private TextMeshProUGUI _text;
  [SerializeField] private TextMeshProUGUI _finishBosstext;

  private void Update()
  {
    switch (State.State)
    {
      case GameStateSO.GameState.StartGame:
        StartCoroutine(WaitToEnable(enableTime));
        break;
      case GameStateSO.GameState.PlayGame:
        _text.gameObject.SetActive(false);
        break;
      case GameStateSO.GameState.BossFight:

        break;
      case GameStateSO.GameState.EndGame:
        _finishBosstext.gameObject.SetActive(true);
        break;
      case GameStateSO.GameState.GameOver:
        break;
  
    }
  }

  IEnumerator WaitToEnable(float time)
  {
    yield return new WaitForSeconds(time);
    _text.gameObject.SetActive(true);
    
  }
}
