using System.Collections.Generic;
using UnityEngine;

namespace GavranGame
{
    public sealed class BafController
    {
        private readonly List<IBaf> bafs;
        private IBaf _rabdomBaf;
        public BafController()
        {
            bafs = new List<IBaf>()
            {
                new TemporarySpeedBoost()
            };

            RabdomBaf = bafs[Random.Range(0, bafs.Count)];
        }

        public IBaf RabdomBaf
        {
            get => _rabdomBaf;
            private set => _rabdomBaf = value;
        }
    }
}