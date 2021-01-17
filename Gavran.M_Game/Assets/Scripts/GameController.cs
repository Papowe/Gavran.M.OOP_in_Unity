using System;
using UnityEngine;

namespace GavranGame
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private InteractiveObject[] _interactiveObjects;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        }

        private void Update()
        {
            for (int i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }

                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }

                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }
    }
}