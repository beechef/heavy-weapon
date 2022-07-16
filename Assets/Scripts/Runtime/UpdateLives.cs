using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLives : MonoBehaviour
{
    [SerializeField] private GameStateSO GameState;
    // Update is called once per frame
    void Update()
    {
        if (GameState.lives == 3)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }else if (GameState.lives == 2)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }

    }
}
