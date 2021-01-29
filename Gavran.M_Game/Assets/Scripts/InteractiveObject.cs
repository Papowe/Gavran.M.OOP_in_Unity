using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IComparable<InteractiveObject>
    {
        protected Color _color;
        public bool isInteractable { get; } = true;
        protected abstract void Interaction(); 
        //public Action<InteractiveObject> OnInteraction;

        private void Start()
        {
            Action();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isInteractable || !other.TryGetComponent<Player>(out Player player)) { return; }
            Interaction();
            //OnInteraction(this);
            Destroy(gameObject);
        }

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }

        public void Action()
        {
            _color = Random.ColorHSV(0f,1f,1f,1f,1f,1f);
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }
    }
}
