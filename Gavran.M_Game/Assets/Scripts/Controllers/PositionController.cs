using System;

namespace GavranGame
{
    public class PositionController : IExecute
    {
        private PlayerBase player;
        public Action OutsideMap = delegate {  };

        public PositionController(PlayerBase player)
        {
            this.player = player;
        }

        public void Execute(float deltaTime)
        {
            if (player.transform.position.y < -10)
            {
                OutsideMap();
            }
        }
    }
}