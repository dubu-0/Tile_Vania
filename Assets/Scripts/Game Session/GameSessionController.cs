using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game_Session
{
    public class GameSessionController : MonoBehaviour
    {
        private void Start()
        {
            if (GetNextSceneBuildIndex() - 1 == 0)
            {
                FindObjectOfType<Player.Player>().DisableMovement();   
            }
        }

        public void RestartCurrentScene(float afterSeconds)
        {
            StartCoroutine(RestartingCurrentScene(afterSeconds));
        }

        public bool TryLoadNextScene(float afterSeconds)
        {
            if (GetNextSceneBuildIndex() < SceneManager.sceneCountInBuildSettings)
            {
                StartCoroutine(LoadingNextScene(afterSeconds));
            }

            return GetNextSceneBuildIndex() < SceneManager.sceneCountInBuildSettings;
        }

        private IEnumerator LoadingNextScene(float afterSeconds)
        {
            PlayerComponentCollection.Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(afterSeconds);
            SceneManager.LoadScene(GetNextSceneBuildIndex());
        }
    
        private IEnumerator RestartingCurrentScene(float afterSeconds)
        {
            yield return new WaitForSeconds(afterSeconds);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
        private int GetNextSceneBuildIndex() => SceneManager.GetActiveScene().buildIndex + 1;
    }
}
