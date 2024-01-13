using UnityEngine;

namespace TapOnTime
{
    [CreateAssetMenu(menuName = "Tap On Time/Arrow Rotating Data", fileName = "Arrow Rotating Data")]
    public class ArrowRotatingData : ScriptableObject
    {
        [SerializeField, Range(5f, 500f)] float rotatingSpeed;
        [SerializeField] Vector3 rotatingDir;

        public float RotatingSpeed { get => rotatingSpeed; }
        public Vector3 RotatingDir { get => rotatingDir; }
    }
}
