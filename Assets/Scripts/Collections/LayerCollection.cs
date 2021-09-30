using UnityEngine;

namespace Collections
{
    public static class LayerCollection
    {
        public static int Ladder { get; } = LayerMask.GetMask(nameof(Ladder));
        public static int Foreground { get; } = LayerMask.GetMask(nameof(Foreground));
    }
}