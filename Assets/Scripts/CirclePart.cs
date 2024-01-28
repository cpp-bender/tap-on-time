using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    [System.Serializable]
    public class CirclePart : MonoBehaviour
    {
        public RectTransform circle;
        public float min;
        public float max;

        public VoidEventChannelSO testEvent;
        
        public void Check(double t)
        {
            if (t >= min && t<=max)
            {
                //TODO: Do stuff
                Debug.Log("+1");
                testEvent?.Raise();
            }
            else
            {
                //TODO: Do nothing
            }
        }
    }
}
