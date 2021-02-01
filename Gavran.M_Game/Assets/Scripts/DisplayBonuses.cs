using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

namespace GavranGame
{
    public sealed class DisplayBonuses
    {
        private Text _bonuseLable;

        public DisplayBonuses(GameObject bonus)
        {
            _bonuseLable = bonus.GetComponentInChildren<Text>();
            _bonuseLable.text = $"Вы набрали 0";
        }

        public void Display(int value)
        {
            _bonuseLable.text = $"Вы набрали {value}";
        }
    }
}