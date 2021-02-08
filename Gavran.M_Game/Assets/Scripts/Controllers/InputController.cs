using UnityEngine;

namespace GavranGame
{
    public class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly KeyCode _savePlayer = KeyCode.C;
        private readonly KeyCode _loadPlayer = KeyCode.V;
        
        public InputController(PlayerBase player)
        {
            _playerBase = player;

            _saveDataRepository = new SaveDataRepository();
        }

        public void Execute()
        {
            if(!_playerBase.isFloor) return;
            _playerBase.Move(Input.GetAxis(AxisManager.HORIZONTAL), 0,Input.GetAxis(AxisManager.VERTICAL));

            if (Input.GetKeyDown(_savePlayer))
            {
                _saveDataRepository.Save(_playerBase);
            }

            if (Input.GetKeyDown(_loadPlayer))
            {
                _saveDataRepository.Load(_playerBase);
            }
        }
    }
}