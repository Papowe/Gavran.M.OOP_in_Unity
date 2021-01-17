﻿using UnityEngine;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        private Material _material;
        private float _lengthFlay;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1f,5f);
        }

        protected override void Interaction()
        {
           //add bonus
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1f));
        }
    }
}
