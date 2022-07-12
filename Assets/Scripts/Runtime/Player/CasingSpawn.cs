using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Rigidbody2D controlRigid;
    [SerializeField] private float Force =2f;
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
