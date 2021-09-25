using System;
using UnityEngine;

namespace Settings
{
    public class InputAxesNames : ScriptableObject
    {
        public static string Horizontal => nameof(Horizontal);
        public static string Vertical => nameof(Vertical);
    }
}