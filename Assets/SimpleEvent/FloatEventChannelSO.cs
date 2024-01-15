using UnityEngine.Events;
using UnityEngine;

namespace SimpleEvent
{
    [CreateAssetMenu(menuName = "Simple Event/Float Event", fileName = "Float Event ")]
    public class FloatEventChannelSO : ScriptableObject
    {
        public event UnityAction<float> OnEventRaised;

        public void Raise(float arg)
        {
            OnEventRaised?.Invoke(arg);
        }
    }
}