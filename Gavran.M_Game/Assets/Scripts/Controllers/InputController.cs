using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GavranGame
{
    public class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly SaveDataRepository _saveDataRepository;
        private List<GoodBonus> goodBonusList;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;
        
        public InputController(PlayerBase player)
        {
            _playerBase = player;
            
            _saveDataRepository = new SaveDataRepository();
            goodBonusList = GameObject.FindObjectsOfType<GoodBonus>().ToList();
        }

        public void Execute(float deltaTime)
        {
            if(!_playerBase.isFloor) return;
            _playerBase.Move(Input.GetAxis(AxisManager.HORIZONTAL), 0,Input.GetAxis(AxisManager.VERTICAL));

            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_playerBase, goodBonusList);
            }

            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_playerBase, goodBonusList);
            }
        }
    }
}