using UnityEngine;

namespace TapOnTime
{
    [System.Serializable]
    public class CirclePart : MonoBehaviour
    {
        public RectTransform circle;
        public float min;
        public float max;
        
        public void Check(double t)
        {
            if (t >= min && t<=max)
            {
                //TODO: Do stuff
                Debug.Log("+1");
            }
            else
            {
                //TODO: Do nothing
            }
        }
    }
}
