using Collections;
using Player;
using UnityEngine;

namespace Game_Session
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] private GameSessionController gameSessionController;
        [SerializeField] private float teleportDuration = 1.5f;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player.Player>() != null)
            {
                PlayerComponentCollection.Animator.SetBool(AnimatorParameters.IsTeleporting, true);
                gameSessionController.TryLoadNextScene(teleportDuration);
            }
        }
    }
}
