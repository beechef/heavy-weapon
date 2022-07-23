using System;
using System.Collections;
using System.Collections.Generic;
using Runtime.Player;
using UnityEngine;

public class UpdateLives : MonoBehaviour
{
    [SerializeField] private GameStateSO state;
    void Update()
    {
        switch (state.ingameLives)
        {
            case 3:
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                break;
            default:
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                break;
        }
    }
}
