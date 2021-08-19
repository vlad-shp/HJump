using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class BallTracking : MonoBehaviour
    {
        private Ball _ball;
        private Vector3 _cameraPosition;
        private Vector3 _minimumBallPosition;

        [SerializeField] private float _length;
        [SerializeField] private Vector3 _directionOffset;

        private void Start()
        {
            _ball = FindObjectOfType<Ball>();

            _minimumBallPosition = _cameraPosition = _ball.transform.position;

            TrackBall();
        }

        private void Update()
        {
            if (_ball.transform.position.y < _minimumBallPosition.y)
            {
                TrackBall();

                _minimumBallPosition = _ball.transform.position;
            }
        }

        private void TrackBall()
        {
            _cameraPosition = _ball.transform.position;

            var direction = (new Vector3(0, _ball.transform.position.y,0) - _ball.transform.position).normalized + _directionOffset;

            _cameraPosition -= direction * _length;

            transform.position = _cameraPosition;

            transform.LookAt(_ball.transform);
        }
    }
}
