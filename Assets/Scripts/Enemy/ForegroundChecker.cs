using UnityEngine;

namespace Enemy
{
    public class ForegroundChecker : MonoBehaviour
    {
        // Triggers when enemy reaches the end of the ground
        private void OnTriggerExit2D(Collider2D other) => GetComponentInParent<EnemyMovement>().SwitchWalkDirection();
    }
}