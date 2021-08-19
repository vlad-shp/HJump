using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        [SerializeField] private float _jumpSpeed = 5f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Jump(float speed = 0)
        {
            _rigidbody.velocity = new Vector3(0,_jumpSpeed,0);
        }
    }
}