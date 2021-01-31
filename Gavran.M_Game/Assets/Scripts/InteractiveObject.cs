using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        protected Color _color;
        private bool _isInteractable;

        public bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.TryGetComponent(out PlayerBase player)) { return; }
            Interaction();
            IsInteractable = false;
        }

        protected abstract void Interaction();
        public abstract void Execute();

        private void Start()
        {
            IsInteractable = true;
            _color = Random.ColorHSV(0f,1f,1f,1f,1f,1f);
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }
    }
}
