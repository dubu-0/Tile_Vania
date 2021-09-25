using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundChecker : MonoBehaviour
{
    // Triggers when enemy reaches the end of the ground
    private void OnTriggerExit2D(Collider2D other) => GetComponentInParent<Enemy.EnemyMovement>().SwitchWalkDirection();
}