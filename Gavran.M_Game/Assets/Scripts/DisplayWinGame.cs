using System;
using UnityEngine;
using UnityEngine.UI;

namespace GavranGame
{
    public class DisplayWinGame
    {
        private Text _winGamelable;
        private GameObject _winGame;
        private Button _restartButton;
        public DisplayWinGame(GameObject winGame, Button restartButton)
        {
            _restartButton = restartButton;
            _winGame = winGame;
            _winGame.SetActive(false);
            _winGamelable = winGame.GetComponentInChildren<Text>();
            _winGamelable.text = String.Empty;
        }

        public void WinPanel()
        {
            Time.timeScale = 0;
            _restartButton.gameObject.SetActive(true);
            _winGame.SetActive(true);
            _winGamelable.text = $"Вы победили!!!";
        }
    }
}