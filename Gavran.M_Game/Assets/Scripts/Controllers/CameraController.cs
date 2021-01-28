using UnityEngine;

namespace GavranGame
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private Vector3 _offset;

        private void Start()
        {
            _player = FindObjectOfType<Player>();
            _offset = transform.position - _player.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = _player.transform.position + _offset;
        }

    }
}
