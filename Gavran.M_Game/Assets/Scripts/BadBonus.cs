using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {
        public Action<string, Color> OnCaughtPlayerChange = delegate(string s, Color color) {  };
        private float _lengthFlay;
        private float _speedRotation;
        
        private void Awake()
        {
            _lengthFlay = Random.Range(1f, 5f);
            _speedRotation = Random.Range(10f, 50f);
        }

        protected override void Interaction()
        {
            OnCaughtPlayerChange?.Invoke(gameObject.name, _color);
        }

        public override void Execute(float deltaTime)
        {
            if(!IsInteractable) return;
            Fly();
            Rotation(deltaTime);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotation(float deltaTime)
        {
            transform.Rotate(Vector3.up * (deltaTime * _speedRotation),Space.World);        
        }
    }
}