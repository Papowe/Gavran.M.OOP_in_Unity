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
        public Text _finishGameLable;
        private DisplayEndGame _displayEndGame;
        //[SerializeField] private List<InteractiveObject> _interactiveObjects;
        private ListInteractableObject _interactiveObjects;
        

        private void Awake()
        {
            // _interactiveObjects = FindObjectsOfType<InteractiveObject>().ToList();
            //
            // foreach (var item in _interactiveObjects)
            // {
            //     item.OnInteraction = o =>
            //     {
            //         var goodBonus = o as GoodBonus;
            //         
            //         if (goodBonus != null)
            //         {
            //             TryRemoveBonus(goodBonus);
            //         }
            //     };
            // }

            _interactiveObjects = new ListInteractableObject();
            _displayEndGame = new DisplayEndGame(_finishGameLable);
            foreach (var o in _interactiveObjects)
            {
                if (o is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaugthPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                }
            }
        }

        private void CaugthPlayer()
        {
            Time.timeScale = 0;
        }

        private void Update()
        {
            for (int i = 0; i < _interactiveObjects.Count; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }

                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }

                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                if (o is InteractiveObject interactiveObject)
                {
                    Destroy(interactiveObject.gameObject);
                    if (o is BadBonus badBonus)
                    {
                        badBonus.CaughtPlayer -= CaugthPlayer;
                        badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    }
                }
            }
        }
        
        // public void TryRemoveBonus(GoodBonus obj)
        // {
        //     if (_interactiveObjects.Contains(obj))
        //     {
        //         _interactiveObjects.Remove(obj);
        //     }
        //
        //     if (!_interactiveObjects.Any(x => x is GoodBonus))
        //     {
        //         Debug.Log("Выиграли");
        //     }
        // }
    }
    
    
}