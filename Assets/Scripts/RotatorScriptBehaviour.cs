using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScriptBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;
    [SerializeField] private int _direction = 1;
    [SerializeField] private Transform _stickTransform;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_direction * Vector3.up * _speed * Time.deltaTime);
    }
}
