using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private List<Platform> _platforms;
        [SerializeField] private StartPlatform _startPlatform;
        [SerializeField] private FinishPlatform _finishPlatform;
        [SerializeField] private int _level;
        [SerializeField] private int _platformMultiplayer;

        private float _rotateAngleStep = 30f;
        private int _rotateAngleMaxSteps = 12;

        private float _buildOffsetY = -2f;

        private void Awake()
        {
            Build(_startPlatform, _finishPlatform, _platforms);
        }

        private void Build(StartPlatform startPlatform, FinishPlatform finishPlatform, List<Platform> platforms)
        {
            var buildPosition = transform.position;
            BuildPlatform(startPlatform,ref buildPosition, _buildOffsetY,  Quaternion.identity, transform);

            PlatformBuilder(ref buildPosition, platforms);

            BuildPlatform(finishPlatform, ref buildPosition, _buildOffsetY, Quaternion.identity, transform);
        }

        private void PlatformBuilder(ref Vector3 buildPosition, List<Platform> platforms)
        {
            for (var i = 0; i < _level * _platformMultiplayer; i++)
            {
                var selectedPlatforms = SelectingPlatforms(platforms);
                var randomPlatformIndex = Random.Range(0, selectedPlatforms.Count);

                BuildPlatform(selectedPlatforms[randomPlatformIndex], ref buildPosition, _buildOffsetY, Quaternion.Euler(0, Random.Range(0, _rotateAngleMaxSteps) * _rotateAngleStep, 0), transform);
            }
        }

        private List<Platform> SelectingPlatforms(IEnumerable<Platform> platforms)
        {
            var selectedPlatforms = new List<Platform>();

            var chance = Random.Range(0, 1f);

            foreach (var platform in platforms)
            {
                if (platform.BuildChanse >= chance)
                {
                    selectedPlatforms.Add(platform);
                }
            }

            return selectedPlatforms;
        }

        private void BuildPlatform(Platform platform, ref Vector3 buildPosition, float buildOffsetY, Quaternion rotation,
            Transform parent)
        {
            Instantiate(platform, buildPosition, rotation, parent);

            buildPosition.y += buildOffsetY;
        }
    }
}                                                  
