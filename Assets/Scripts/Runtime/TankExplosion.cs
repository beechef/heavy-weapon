using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankExplosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private AudioSource explosionAudio;
    [SerializeField] private GameStateSO gameState;
    [SerializeField] private SpriteRenderer tankMesh;
    [SerializeField] private GameObject tankBarrel;
    private void Start()
    {
        explosionEffect.Stop();
    }

    public void Update()
    {
        if (gameState.State == GameStateSO.GameState.Dead)
        {
            Exposion();
        }
    }

    public void Exposion()
    {
        tankBarrel.SetActive(false);
        tankMesh.enabled = false;
        explosionEffect.Play();
        explosionAudio.Play();
    }
}
