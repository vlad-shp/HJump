using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private Ball _ball;

        private BallSpawnPoint _ballSpawnPoint;

        private void Start()
        {
            _ballSpawnPoint = FindObjectOfType<BallSpawnPoint>();
            SpawnBall(_ball, _ballSpawnPoint);
        }

        private void SpawnBall(Ball ball, BallSpawnPoint ballSpawnPoint)
        {
            Instantiate(ball, ballSpawnPoint.transform.position, Quaternion.identity, null);
        }
    }
}

