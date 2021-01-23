using System;
using UnityEngine;

namespace GavranGame
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerBall : Player
    {
        private bool _isFloor = true;

        private void Update()
        {
            if (!_isFloor) return;
            Jump();
        }

        private void FixedUpdate()
        {
            if (!_isFloor) return;
            Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Floor>(out Floor floor))
            {
                _isFloor = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Floor>(out Floor floor))
            {
                _isFloor = false;
            }
        }

       
    }
}

