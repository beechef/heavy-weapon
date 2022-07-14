using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class OnMouseEnterBtn : MonoBehaviour
{
    [SerializeField] private AudioSource onMouseEnterAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        onMouseEnterAudio.Play();
    }
}
