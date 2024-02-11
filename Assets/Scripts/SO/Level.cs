using UnityEngine;

namespace TapOnTime
{
    [CreateAssetMenu(menuName = "Tap On Time / Level", fileName = "Level 0")]
    public class Level : ScriptableObject
    {
        [SerializeField, Tooltip("Level")] int index;
        [SerializeField, Tooltip("Target score")] int score;

        public int Index { get => index; }
        public int Score { get => score; }
    }
}
