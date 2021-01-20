using System.Collections.Generic;

namespace GavranGame
{
    public sealed class GoodBonusesEqualityComparer : IEqualityComparer<GoodBonus>
    {
        public bool Equals(GoodBonus x, GoodBonus y)
        {
            return x._point == y._point;
        }

        public int GetHashCode(GoodBonus obj)
        {
            return obj._point.GetHashCode();
        }
    }
}