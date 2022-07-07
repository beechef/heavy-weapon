using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootByPressMouse : MonoBehaviour
{
    [SerializeField] private Transform barrelTrans;
    [SerializeField] private Transform podTrans;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject casingPrefab;
    [SerializeField] private AudioSource tankFireAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // create bullet, config direction
            tankFireAudio.Play();
            var bullet = Instantiate(bulletPrefab, barrelTrans.position, barrelTrans.rotation).transform;
            bullet.up = barrelTrans.up;
            var casing = Instantiate(casingPrefab, podTrans.position, Quaternion.Euler(-5,0,0)).transform;
           
        }
    }
}
