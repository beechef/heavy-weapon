using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkSize : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.Log(_spriteRenderer.bounds.size.x);
    }
}
