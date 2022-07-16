using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TankExplosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private AudioSource explosionAudio;
    [SerializeField] private SpriteRenderer tankMesh;
    [SerializeField] private GameObject tankBarrel;
    [SerializeField] private UnityEvent tankExplosionEvent;
    private void Start()
    {
        explosionEffect.Stop();
    }

    public void Update()
    {
        
    }

    public void ExplosionByPress()
    {
        tankExplosionEvent.Invoke();
    }

    public void ExplsionEffect()
    {
        tankBarrel.SetActive(false);
        tankMesh.enabled = false;
        explosionEffect.Play();
        explosionAudio.Play();
    }
}
