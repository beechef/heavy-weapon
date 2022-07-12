using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.transform.position + offset;
    }
}
