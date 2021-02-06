using System;
using UnityEngine;

namespace GavranGame
{
    public class ListGoodBonuses
    {
        private int _countGoodBonusesObject;
        public Action BonusesCollected = delegate {  };
        
        public ListGoodBonuses(ListExecuteObject listExecuteObject)
        {
            foreach (var o in listExecuteObject)
            {
                if (o is GoodBonus)
                {
                    CountGoodBonusesObject++;
                }
            }
        }

        public int CountGoodBonusesObject
        {
            get { return _countGoodBonusesObject; }
            private set
            {
                _countGoodBonusesObject = value;
                if (_countGoodBonusesObject <= 0)
                {
                    BonusesCollected();
                }
            }
        }

        public void CaughtBonus()
        {
            CountGoodBonusesObject--;
        }
    }
}