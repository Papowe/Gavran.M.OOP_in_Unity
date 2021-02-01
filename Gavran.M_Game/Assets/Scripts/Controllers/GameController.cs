using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GavranGame
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        public PlayerType PlayerType = PlayerType.Ball;
       private ListExecuteObject _interactiveObject;
       private DisplayEndGame _displayEndGame;
       private DisplayWinGame _displayWinGame;
       private DisplayBonuses _displayBonuses;
       private Refeerence _refeerence;
       private CameraController _cameraController;
       private InputController _inputController;
       private ListGoodBonuses _listGoodBonuses;
       private int _countBonuses;

       private void Awake()
       {
           _refeerence = new Refeerence();
           _interactiveObject = new ListExecuteObject();
           _listGoodBonuses = new ListGoodBonuses(_interactiveObject);
           _displayEndGame = new DisplayEndGame(_refeerence.EndGame);
           _displayWinGame = new DisplayWinGame(_refeerence.WinGame, _refeerence.RestartButton);
           _displayBonuses = new DisplayBonuses(_refeerence.Bonuse);

           PlayerBase player = null;
           if (PlayerType == PlayerType.Ball)
           {
               player = _refeerence.PlayerBall;
           }

           _cameraController = new CameraController(player.transform,_refeerence.MainCamera.transform);
           _interactiveObject.AddExecuteObject(_cameraController);

           if (Application.platform == RuntimePlatform.WindowsEditor)
           {
               _inputController = new InputController(player);
               _interactiveObject.AddExecuteObject(_inputController);
           }

           foreach (var o in _interactiveObject)
           {
               if (o is BadBonus badBonus)
               {
                   badBonus.OnCaughtPlayerChange += CaughtPlayer;
                   badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
               }

               if (o is GoodBonus goodBonus)
               {
                   goodBonus.OnPointChange += AddBonuse;
               }
           }

           _listGoodBonuses.BonusesCollected += _displayWinGame.WinPanel;
           
           _refeerence.RestartButton.onClick.AddListener(RestartGame);
           _refeerence.RestartButton.gameObject.SetActive(false);
       }

       private void RestartGame()
       {
           SceneManager.LoadScene(0);
           Time.timeScale = 1;
       }
       
       private void CaughtPlayer(string value, Color args)
       {
           _refeerence.RestartButton.gameObject.SetActive(true);
           Time.timeScale = 0;
       }

       private void AddBonuse(int value)
       {
           _countBonuses += value;
           _displayBonuses.Display(_countBonuses);
           _listGoodBonuses.CaughtBonus();
       }

       private void Update()
       {
           for (int i = 0; i < _interactiveObject.Length; i++)
           {
               var interactiveObject = _interactiveObject[i];

               if (interactiveObject == null)
               {
                   continue;
               }
               interactiveObject.Execute();
           }
       }

       public void Dispose()
       {
           foreach (var o in _interactiveObject)
           {
               switch (o)
               {
                   case BadBonus badBonus:
                       badBonus.OnCaughtPlayerChange -= CaughtPlayer;
                       badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                       break;
                   case GoodBonus goodBonus:
                       goodBonus.OnPointChange -= AddBonuse;
                       break;
               }
           }
           
           _listGoodBonuses.BonusesCollected -= _displayWinGame.WinPanel;
       }
    }
}