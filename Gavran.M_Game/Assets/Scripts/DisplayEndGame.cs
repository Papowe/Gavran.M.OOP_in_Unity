using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

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

        public void GameOver(object o, CaughtPlayerEventArgs args)
        {
            _finishGameLabel.text = $"Вы проиграли. Вас убил {((BadBonus)o)?.name} {args.Color} цвета";
        }
    }
}