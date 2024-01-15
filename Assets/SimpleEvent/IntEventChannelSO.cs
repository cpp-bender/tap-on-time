using UnityEngine.Events;
using UnityEngine;

namespace SimpleEvent
{
    [CreateAssetMenu(menuName = "Simple Event/Int Event", fileName = "Int Event")]
    public class IntEventChannelSO : ScriptableObject
    {
        public event UnityAction<int> Event;

        public void Raise(int param)
        {
            Event?.Invoke(param);
        }
    }
}
