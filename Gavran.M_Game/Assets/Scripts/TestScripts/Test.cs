using System;
using System.IO;
using UnityEngine;

namespace GavranGame
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            try
            {
                Division(5, 0);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        
        private void Division(object a, object b)
        {
            if (Convert.ToInt32(b) == 0)
            {
                throw new Exception("Деление на ноль");
            }
            var x = Convert.ToInt32(a) / Convert.ToInt32(b);
            Debug.Log($"{a} / {b} = {x}");
        }
    }
}