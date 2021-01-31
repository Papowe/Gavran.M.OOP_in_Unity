using System;
using UnityEngine;

namespace GavranGame
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public float Speed = 4;

        public abstract void Move(float x, float y, float z);
    }
}
