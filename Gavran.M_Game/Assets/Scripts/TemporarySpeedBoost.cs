using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

namespace GavranGame
{
    public sealed class TemporarySpeedBoost : IBaf
    {
        private float _curentSpeed;
        
        public void Baf(PlayerBase playerBase)
        {
            _curentSpeed = playerBase.Speed;
            playerBase.Speed = 10f;
        }

        // IEnumerator TimeSpeed(PlayerBase playerBase)
        // {
        //     _curentSpeed = playerBase.Speed;
        //     playerBase.Speed = 20f;
        //     yield return new WaitForSeconds(5);
        //     playerBase.Speed = _curentSpeed;
        // }
    }
}