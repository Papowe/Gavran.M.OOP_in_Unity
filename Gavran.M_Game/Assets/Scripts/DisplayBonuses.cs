using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

namespace GavranGame
{
    public sealed class DisplayBonuses
    {
        private static Text _text;

        public DisplayBonuses()
        {
            //_text = Object.FindObjectOfType<Text>();
        }

        public void Display(int value)
        {
            _text.text = $"Вы набрали {value}";
        }
    }
}