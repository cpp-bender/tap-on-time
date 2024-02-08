using UnityEngine;
using SimpleEvent;
using System;

namespace TapOnTime
{
    [Serializable]
    public class CirclePart : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] RectTransform circle;
        [SerializeField] float[] min;
        [SerializeField] float[] max;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO changeCirclePartEvent;
        [SerializeField] VoidEventChannelSO makeProgressEvent;

        public void Check(float t)
        {
            for (int i = 0; i < max.Length; i++)
            {
                if (t >= min[i] && t <= max[i])
                {
                    changeCirclePartEvent.Raise();
                    //TODO: change event to float channel
                    makeProgressEvent.Raise();
                }
                else
                {

                }
            }
        }
    }
}
