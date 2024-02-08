using UnityEngine;

namespace TapOnTime
{
    [CreateAssetMenu(menuName = "Tap On Time / Level", fileName = "Level 0")]
    public class Level : ScriptableObject
    {
        [SerializeField] int index;

        public int Index { get => index; }
    }
}
