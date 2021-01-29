using System;
using UnityEngine;

namespace GavranGame
{
    public class DelegatesObserver
    {
        public delegate void MyDelegate(object o);
        
        public  sealed class Source
        {
            private event MyDelegate _function;
            
            public void Add(MyDelegate f) // Метод для підписки методів на делегат
            {
                _function += f;
            }

            public void Remove(MyDelegate f) // Метод для відписки методів на делегат
            {
                _function -= f;
            }

            public void Run()
            {
                Debug.Log("Runs!");
                _function?.Invoke(this);
            }
        }
        
        public sealed class Observer1 // Наглядач 1
        {
            public void Do(object o)
            {
                Debug.Log($"Перший. Прийняв що обєкт {o} побіг");
            }
        }
        
        public sealed class Observer2 // Наглядач 2
        {
            public void Do(object o)
            {
                Debug.Log($"Другий. Прийняв що обєкт {o} побіг");
            }
        }
    }
}