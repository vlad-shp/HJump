using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Portal : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out Ball component))
            {
                GetComponentInParent<Platform>().Explode();

                ScoreSystem.Instance.IncrementScore();
            }
        }
    }
}