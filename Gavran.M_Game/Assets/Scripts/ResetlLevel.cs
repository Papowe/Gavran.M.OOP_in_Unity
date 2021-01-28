using UnityEngine;
using UnityEngine.SceneManagement;

namespace GavranGame
{
    public class ResetlLevel : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out  Player player))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
