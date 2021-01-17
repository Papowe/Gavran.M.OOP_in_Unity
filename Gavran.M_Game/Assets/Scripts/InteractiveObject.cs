using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool isInteractable { get; }

        private void Start()
        {
            Action();
        }

        protected abstract void Interaction();
        public void Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

    }
}
