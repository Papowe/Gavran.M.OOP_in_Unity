using System;
using UnityEngine;

namespace GavranGame
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed = 200f;
        [SerializeField] private float _jumpForce = 4f;

        private Rigidbody _playerRigidBody;

        private void Start()
        {
            _playerRigidBody = GetComponent<Rigidbody>();
        }

        protected void Move()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

            _playerRigidBody.AddForce(movement * (_speed * Time.deltaTime));
        }

        protected void Jump()
        {
            Vector3 jumpDirection = Vector3.up;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerRigidBody.AddForce(jumpDirection * _jumpForce, ForceMode.Impulse);
            }
        }

    }

}
