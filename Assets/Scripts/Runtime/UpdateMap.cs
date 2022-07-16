using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMap : MonoBehaviour
{
    [SerializeField] private Slider mapSlider;
    public float distance;
    public Transform player;
    void Start()
    {
        mapSlider.maxValue =  Vector2.Distance(transform.position, player.position);;
        mapSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector2.Distance(transform.position, player.position);
        mapSlider.value += 1f * Time.deltaTime;
    }
}
