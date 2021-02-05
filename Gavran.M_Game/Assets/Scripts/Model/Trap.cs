using System;
using UnityEngine;

namespace GavranGame
{
    public abstract class Trap : MonoBehaviour
    {
        protected Color _colorTrap;
        protected abstract void TrapAction(PlayerBase player);

        private void OnTriggerEnter(Collider other)
        {
            if(!other.TryGetComponent(out PlayerBase player)) { return; }
            TrapAction(player);
        }
    }
}