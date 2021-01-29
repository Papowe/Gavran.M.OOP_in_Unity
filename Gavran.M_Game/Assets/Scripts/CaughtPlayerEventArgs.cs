using System;
using UnityEngine;

namespace GavranGame
{
    public class CaughtPlayerEventArgs : EventArgs
    {
        public Color Color { get; }

        public CaughtPlayerEventArgs(Color color)
        {
            Color = color;
        }
    }
}