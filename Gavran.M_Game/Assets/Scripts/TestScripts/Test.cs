using System;
using System.Collections.Generic;
using UnityEngine;
using static GavranGame.DelegatesObserver;

namespace GavranGame
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            Source s = new Source();
            Observer1 o1 = new Observer1();
            Observer2 o2 = new Observer2();
            
            MyDelegate d1 = new MyDelegate(o1.Do);
            s.Add(d1);
            s.Add(o2.Do);
            
            s.Run();
            s.Remove(o1.Do);
            s.Run();

        }
    }
}