using UnityEngine;
using UnityEngine.SceneManagement;

namespace GavranGame
{
    public class ResetlLevel : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
