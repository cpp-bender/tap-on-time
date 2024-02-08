using UnityEngine;
using SimpleEvent;
using System;

namespace TapOnTime
{
    [Serializable]
    public class CirclePart : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] float[] min;
        [SerializeField] float[] max;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO tapSuccessEvent;

        public void Check(float t)
        {
            for (int i = 0; i < max.Length; i++)
            {
                if (t >= min[i] && t <= max[i])
                {
                    tapSuccessEvent.Raise();
                }
                else
                {

                }
            }
        }
    }
}
