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
        private ListGoodBonuses _listGoodBonuses;
        private int _countBonuses;

        public DisplayBonuses(Refeerence refeerence, ListGoodBonuses listGoodBonuses)
        {
            _listGoodBonuses = listGoodBonuses;
            _bonuseLable = refeerence.Bonuse.GetComponentInChildren<Text>();
            _bonuseLable.text = $"Вы набрали 0";
        }

        public void Display(int value)
        {
            _bonuseLable.text = $"Вы набрали {value}";
        }
        
        public void AddBonuse(int value)
        {    
            _countBonuses += value;
            Display(_countBonuses);
            _listGoodBonuses.CaughtBonus();
        }
    }
}