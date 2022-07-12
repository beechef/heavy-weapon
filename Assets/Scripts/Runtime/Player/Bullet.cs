using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private Rigidbody2D controlRigid;
    [SerializeField] private float Force =20f;
    void Start()
    {
        var velo = transform.up * Force;
        controlRigid.velocity = velo;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

