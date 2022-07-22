using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class spawnGround : MonoBehaviour
{
    public GameObject groundsCombie;
    public GameObject ground;

    private void Start()
    {
        var newGround =Instantiate(ground, new Vector3(0,transform.position.y,0), Quaternion.identity);
        newGround.transform.parent = groundsCombie.transform;
        var newGround2 =Instantiate(ground, transform.position, Quaternion.identity);
        newGround2.transform.parent = groundsCombie.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (groundsCombie.transform.childCount <= 1)
        {
            var newGround =Instantiate(ground, transform.position, Quaternion.identity);
            newGround.transform.parent = groundsCombie.transform;
        }
    }
}
