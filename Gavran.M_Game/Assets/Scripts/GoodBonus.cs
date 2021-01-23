using System;
using UnityEngine;
using static UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace GavranGame
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker, ICloneable, IEquatable<GoodBonus>
    {
        public int _point;
        private DisplayBonuses _displayBonuses;
        private Material _material;
        private float _lengthFlay;

        private void Awake()
        {
            _displayBonuses = new DisplayBonuses();
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1f,5f);
            _point = Random.Range(1, 5);
        }
        
        protected override void Interaction()
        {
            _displayBonuses.Display(_point);
            Log("I get a bonus");
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1f));
        }

        public object Clone()
        {
            var cloneGameObject = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
            return cloneGameObject;
        }

        public bool Equals(GoodBonus other)
        {
            return _point == other._point;
        }
    }
}
