using System;
using UnityEngine.UI;

namespace GavranGame
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        public DisplayEndGame(Text finishGameLable)
        {
            _finishGameLabel = finishGameLable;
            _finishGameLabel.text = String.Empty;
        }

        public void GameOver()
        {
            _finishGameLabel.text = "Вы проиграли";
        }
    }
}