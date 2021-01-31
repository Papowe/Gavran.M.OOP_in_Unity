using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace GavranGame
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        public DisplayEndGame(GameObject endGame)
        {
            _finishGameLabel = endGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _finishGameLabel.text = $"Вы проиграли, вас убил {name}, {color} цвета";
        }
    }
}