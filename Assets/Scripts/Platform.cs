using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Platform : MonoBehaviour
    {
        public float BuildChanse;

        private const float ExplodeForce = 200f;
        private const float ExplodeRadius = 200f;

        public void Explode(float force = ExplodeForce, float radius = ExplodeRadius)
        {
            var segments = GetComponentsInChildren<PlatformSegment>();

            foreach (var segment in segments)
            {
                segment.Explode(force, transform.position, radius);
            }

            var portals = GetComponentsInChildren<Portal>();

            foreach (var portal in portals)
            {
                Destroy(portal.gameObject);
            }

        }
    }
}
