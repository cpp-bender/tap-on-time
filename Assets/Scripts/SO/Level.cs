using UnityEngine;

namespace TapOnTime
{
    [CreateAssetMenu(menuName = "Tap On Time / Level", fileName = "Level 0")]
    public class Level : ScriptableObject
    {
        [SerializeField] int index;
        [SerializeField] int score;

        public int Index { get => index; }
        public int Score { get => score; }
    }
}
