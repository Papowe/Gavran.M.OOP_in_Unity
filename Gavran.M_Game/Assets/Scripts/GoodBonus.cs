using System;
using UnityEngine;
using static UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        public int Point;
        public Action<int> OnPointChange = delegate(int i) {  };
        public Action  ShakingCamera = delegate {  };
        private Material _material;
        private float _lengthFly;

        private void Awake()
        {
            Point = Random.Range(1, 5);
            _material = GetComponent<Renderer>().material;
            _lengthFly = Random.Range(1f, 5f);
        }
        
        protected override void Interaction()
        {
            ShakingCamera();
            OnPointChange(Point);
        }

        public override void Execute(float deltaTime)
        {
            if(!IsInteractable) return;
            Fly();
            Flicker();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1f));
        }
    }
}
