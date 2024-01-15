using UnityEngine.Events;
using UnityEngine;

namespace SimpleEvent
{
    [CreateAssetMenu(menuName = "Simple Event/Void Event", fileName = "Void Event")]
    public class VoidEventChannelSO : ScriptableObject
    {
        public event UnityAction Event;

        public void Raise()
        {
            Event?.Invoke();
        }
    }
}