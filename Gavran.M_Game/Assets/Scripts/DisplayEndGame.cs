using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace GavranGame
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;
        private Refeerence _refeerence;

        public DisplayEndGame(Refeerence refeerence)
        {
            _refeerence = refeerence;
            _finishGameLabel = refeerence.EndGame.GetComponentInChildren<Text>();
            _finishGameLabel.text = String.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _finishGameLabel.text = $"Вы проиграли, вас убил {name}, {color} цвета";
        }
        
        public void CaughtPlayer(string value, Color args)
        {
            _refeerence.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}