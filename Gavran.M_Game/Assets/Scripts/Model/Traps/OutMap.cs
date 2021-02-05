using System;
using UnityEngine;

namespace GavranGame
{
    public class OutMap : Trap
    {
        [SerializeField] private float shotForce = 10f;

        private void Start()
        {
            _colorTrap = Color.red;
            GetComponent<Renderer>().material.color = _colorTrap;
        }

        protected override void TrapAction(PlayerBase player)
        {
            Rigidbody playerRigidBody = player.GetComponent<Rigidbody>();
            playerRigidBody.AddForce(Vector3.up * shotForce, ForceMode.Impulse);
        }
    }
}