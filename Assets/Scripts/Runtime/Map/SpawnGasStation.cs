using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGasStation : MonoBehaviour
{
    private bool gasStattionSpawned;
    [SerializeField] private GameStateSO state;
    [SerializeField] private GameObject gasStation;
    [SerializeField] private Transform groundCombie;
    void Start()
    {
        gasStattionSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state.State == GameStateSO.GameState.BossKilled)
        {
            StartCoroutine(waitToSpawnGasStation(4));

        }
        
    }

    IEnumerator waitToSpawnGasStation(float time)
    {
      
            yield return new WaitForSeconds(time);
            if (gasStattionSpawned) yield break;
            var newGasStation = Instantiate(gasStation, transform.position, Quaternion.identity);
            gasStattionSpawned = true;
            newGasStation.transform.parent = groundCombie.transform.GetChild(1).transform;
    }
}
