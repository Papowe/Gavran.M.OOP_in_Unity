using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GavranGame
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(KeySelector);
            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }

        private int KeySelector(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }
    }
}