using UnityEngine;

namespace TapOnTime
{
    [CreateAssetMenu(menuName = "Tap On Time/Arrow Rotating Data", fileName = "Arrow Rotating Data")]
    public class ArrowRotatingData : ScriptableObject
    {
        [SerializeField, Range(0f, 100f), Tooltip("Distance to the center")] float dist;
        [SerializeField, Tooltip("Initial speed")] float speed;
        [SerializeField, Tooltip("Speed multiply factor")] float t;

        public float Dist { get => dist; }
        public float Speed { get => speed; }
        public float T { get => t;}
    }
}
