﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation, ICloneable
    {
        private float _lengthFlay;
        private float _speedRotation;

        private void Awake()
        {
            _lengthFlay = Random.Range(1f, 5f);
            _speedRotation = Random.Range(10f, 50f);
        }

        protected override void Interaction()
        {
            //destroy
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation),Space.World);        
        }

        public object Clone()
        {
            var cloneGameObject = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return cloneGameObject;
        }
    }
}