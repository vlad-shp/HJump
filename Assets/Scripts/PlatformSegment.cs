using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlatformSegment : MonoBehaviour
    {

        private void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.TryGetComponent(out Ball component))
            {
                component.Jump();
            }
        }

        public void Explode(float force, Vector3 center, float radius)
        {
            if (TryGetComponent(out Rigidbody rb))
            {
                transform.SetParent(null);

                rb.isKinematic = false;
                rb.AddExplosionForce(force, center, radius);


                Invoke(nameof(DestroySegment), 4);
            }
        }

        private void DestroySegment()
        {
            Destroy(gameObject);
        }
    }
}