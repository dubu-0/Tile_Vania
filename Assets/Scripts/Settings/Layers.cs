using UnityEngine;

namespace Settings
{
    public class Layers : ScriptableObject
    {
        public static int Ladder => LayerMask.GetMask(nameof(Ladder));
        public static int Foreground => LayerMask.GetMask(nameof(Foreground));
    
        public static bool IsTouchingLayers(Collider2D collider2D, params int[] layers)
        {
            foreach (var layer in layers)
            {
                if (collider2D.IsTouchingLayers(layer))
                {
                    return true;
                }
            }

            return false;
        }
    }
}