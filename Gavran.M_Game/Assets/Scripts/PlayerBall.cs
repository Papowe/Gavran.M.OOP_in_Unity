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
            if (_isFloor)
            {
                Move();
                Jump();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                _isFloor = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                _isFloor = false;
            }
        }
    }
}

