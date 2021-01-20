using System;
using System.Linq;
using UnityEngine;

namespace GavranGame
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            var listInteractableObject = new  ListInteractableObject();
            for (int i = 0; i < listInteractableObject.Count; i++)
            {
                print(listInteractableObject[i]);
            }
        }
    }
}