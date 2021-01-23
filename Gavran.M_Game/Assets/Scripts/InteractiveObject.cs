﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
    {
        public bool isInteractable { get; } = true;
        protected abstract void Interaction();
        public Action<InteractiveObject> OnInteraction;

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

        private void OnTriggerEnter(Collider other)
        {
            if (!isInteractable || !other.TryGetComponent<Player>(out Player player)) { return; }
            Interaction();
            OnInteraction(this);
            Destroy(gameObject);
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

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }
    }
}
