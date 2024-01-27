using UnityEngine;

namespace TapOnTime
{
    [CreateAssetMenu(menuName = "Tap On Time/Arrow Rotating Data", fileName = "Arrow Rotating Data")]
    public class ArrowRotatingData : ScriptableObject
    {
        [SerializeField, Range(0f, 100f)] float dist;
        [SerializeField] float initSpeed;

        public float Dist { get => dist; }
        public float InitSpeed { get => initSpeed; }
    }
}
