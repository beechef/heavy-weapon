using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKillBoss : MonoBehaviour
{
    [SerializeField] private GameStateSO state;
    public void KillBoss()
    {
        state.EndGame();
    }
}
