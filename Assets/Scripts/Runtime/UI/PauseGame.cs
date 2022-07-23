using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
  public void PauseGameByPress()
  {
    Time.timeScale = 0;
  }

  public void ContinueByPress()
  {
    Time.timeScale = 1;
  }
}
