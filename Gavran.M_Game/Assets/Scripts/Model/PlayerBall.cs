﻿using System;
using UnityEngine;

namespace GavranGame
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerBall : PlayerBase
    {
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * Speed);
        }

        private void OnCollisionEnter(Collision other)
        {
            if(!other.gameObject.TryGetComponent(out Floor floor)) return;
            isFloor = true;
        }

        private void OnCollisionExit(Collision other)
        {
            if(!other.gameObject.TryGetComponent(out Floor floor)) return;
            isFloor = false;
        }
    }
}

