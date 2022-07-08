using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootByPressMouse : MonoBehaviour
{
    [SerializeField] private Transform barrelTrans;
    [SerializeField] private Transform podTrans;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject casingPrefab;
    [SerializeField] private AudioSource tankFireAudio;

    private void Start()
    {
      
    }

    void Update()
    {
        
       
        if (Input.GetMouseButtonDown(0))
        {
            // create bullet, config direction
            tankFireAudio.Play();
            var bullet = Instantiate(bulletPrefab, barrelTrans.position, barrelTrans.rotation).transform;
            bullet.up = barrelTrans.up;
            var casing = Instantiate(casingPrefab, podTrans.position, Quaternion.Euler(-5,0,0)).transform;
            barrelTrans.DORewind();
            barrelTrans.DOPunchPosition(new Vector3(0f,1f,0f) * -0.1f, 0.1f);
            podTrans.DORewind();
            podTrans.DOPunchScale(new Vector3(1f, -1f, 0f) * 0.3f, 0.2f);

        }
    }
}
