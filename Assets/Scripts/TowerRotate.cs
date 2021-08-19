using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotate : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        if (Mathf.Abs(hor)>0.1)
        {
            transform.Rotate(0, hor * 20 * _rotationSpeed * Time.deltaTime, 0);
        }
        else if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                var torque = touch.deltaPosition.x * Time.deltaTime * _rotationSpeed;
                transform.Rotate(0, torque, 0);
            }
            
        }

    }
}
