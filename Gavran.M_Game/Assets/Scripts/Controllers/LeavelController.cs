using UnityEngine;
using UnityEngine.SceneManagement;

namespace GavranGame
{
    public class LeavelController
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }
}