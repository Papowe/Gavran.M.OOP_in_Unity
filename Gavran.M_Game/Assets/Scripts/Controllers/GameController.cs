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
       private PositionController _positionController;
       private LeavelController _leavelController;
       private PlayerBase _player;

       private void Awake()
       {
           _refeerence = new Refeerence();
           _leavelController = new LeavelController();
           _interactiveObject = new ListExecuteObject();
           _listGoodBonuses = new ListGoodBonuses(_interactiveObject);
           _displayEndGame = new DisplayEndGame(_refeerence);
           _displayWinGame = new DisplayWinGame(_refeerence.WinGame, _refeerence.RestartButton);
           _displayBonuses = new DisplayBonuses(_refeerence, _listGoodBonuses);
           
           if (PlayerType == PlayerType.Ball)
           {
               _player = _refeerence.PlayerBall;
           }
            
           _positionController = new PositionController(_player);
           _interactiveObject.AddExecuteObject(_positionController);
           _positionController.OutsideMap += _leavelController.RestartGame;
           
           _cameraController = new CameraController(_player.transform,_refeerence.MainCamera.transform);
           _interactiveObject.AddExecuteObject(_cameraController);

           if (Application.platform == RuntimePlatform.WindowsEditor)
           {
               _inputController = new InputController(_player);
               _interactiveObject.AddExecuteObject(_inputController);
           }

           foreach (var o in _interactiveObject)
           {
               if (o is BadBonus badBonus)
               {
                   badBonus.OnCaughtPlayerChange += _displayEndGame.CaughtPlayer;
                   badBonus.OnCaughtPlayerChange += _displayEndGame.GameOver;
               }

               if (o is GoodBonus goodBonus)
               {
                   goodBonus.OnPointChange += _displayBonuses.AddBonuse;
               }
           }

           _listGoodBonuses.BonusesCollected += _displayWinGame.WinPanel;
           
           _refeerence.RestartButton.onClick.AddListener(_leavelController.RestartGame);
           _refeerence.RestartButton.gameObject.SetActive(false);
       }
       
       private void Update()
       {
           float deltaTime = Time.deltaTime;
           for (int i = 0; i < _interactiveObject.Length; i++)
           {
               var interactiveObject = _interactiveObject[i];

               if (interactiveObject == null)
               {
                   continue;
               }
               interactiveObject.Execute(deltaTime);
           }
       }

       public void Dispose()
       {
           foreach (var o in _interactiveObject)
           {
               switch (o)
               {
                   case BadBonus badBonus:
                       badBonus.OnCaughtPlayerChange -= _displayEndGame.CaughtPlayer;
                       badBonus.OnCaughtPlayerChange -= _displayEndGame.GameOver;
                       break;
                   case GoodBonus goodBonus:
                       goodBonus.OnPointChange -= _displayBonuses.AddBonuse;
                       break;
               }
           }
           
           _positionController.OutsideMap += _leavelController.RestartGame;
           _listGoodBonuses.BonusesCollected -= _displayWinGame.WinPanel;
       }
    }
}