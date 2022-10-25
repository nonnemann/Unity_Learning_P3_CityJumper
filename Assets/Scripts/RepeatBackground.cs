using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPosition;
    private float _repeatWidth;

    private void Start()
    {
        _startPosition = transform.position;
        _repeatWidth = GetComponent<Renderer>().bounds.size.x / 2;
    }

    private void Update()
    {
        if (transform.position.x < _startPosition.x - _repeatWidth)
        {
            transform.position = _startPosition;
        }
    }
}
