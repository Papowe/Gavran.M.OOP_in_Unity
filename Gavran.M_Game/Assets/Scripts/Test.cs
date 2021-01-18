using System;
using UnityEngine;

namespace GavranGame
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            var savedData = new SavedData<Guid>();
            savedData.idPlayer = new Guid();

            var savedDataExample = new SavedData<string>();
            savedDataExample.idPlayer = "name_554";
        }
    }
}