using UnityEngine;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public sealed class BadBonus : InteractiveObject, IFlay, IRotation
    {
        private float _lengthFlay;
        private float _speedRotation;

        private void Awake()
        {
            _lengthFlay = Random.Range(1f, 5f);
            _speedRotation = Random.Range(10f, 50f);
        }

        protected override void Interaction()
        {
            //destroy
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation),Space.World);        
        }
    }
}