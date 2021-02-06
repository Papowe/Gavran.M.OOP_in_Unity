using System;
using UnityEngine;

namespace GavranGame
{
    public class NoBody : Trap
    {
        private void Start()
        {
            _colorTrap = Color.black;
            GetComponent<Renderer>().material.color = _colorTrap;
        }

        protected override void TrapAction(PlayerBase player)
        {
            player.GetComponent<Collider>().enabled = false;
        }
    }
}