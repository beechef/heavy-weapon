using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpdateMap : MonoBehaviour
{
    [SerializeField] private Slider mapSlider;
    public float distance;
    public Transform player;
    [SerializeField] private UnityEvent finishLevelEvent;
    [SerializeField] private GameStateSO state;
    void Start()
     {
        mapSlider.maxValue =  Vector2.Distance(transform.position, player.position);;
        mapSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector2.Distance(transform.position, player.position);
        FinishLevel(distance);
        mapSlider.value += state.moveLeftSpeed * Time.deltaTime;
    }

    private void FinishLevel(float distance)
    {
        if (distance <= 3)
        {
            state.FinishMission();
            finishLevelEvent.Invoke();
        }
    }
}
