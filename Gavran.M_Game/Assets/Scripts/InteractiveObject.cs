using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool isInteractable { get; }
        protected abstract void Interaction();

        private void Start()
        {
            if (this is BadBonus)
            {
                ((IInitialization)this).Action();
            }
            if (this is GoodBonus)
            {
                ((IAction)this).Action();
            }
        }

        void IAction.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

        void IInitialization.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Color.red;;
            }
        }
    }
}
