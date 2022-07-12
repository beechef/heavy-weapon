using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    private LineRenderer track;
    private Vector3 position;

    private void Start()
    {
        track = GetComponent<LineRenderer>();
      
    }

    private void Update()
    { 
        position = transform.position;
        Vector3 endLinePosition = new Vector3(-10, position.y - 0.3f);
        track.SetPosition(0,new Vector3(position.x,position.y-0.3f));
        track.SetPosition(1,endLinePosition);
        if (track.GetPosition(0).magnitude - track.GetPosition(1).magnitude > 10)
        {
            endLinePosition.x += 5;
        }
        track.enabled=true;

    }
}
