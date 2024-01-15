using UnityEngine.Events;
using UnityEngine;

namespace SimpleEvent
{
    [CreateAssetMenu(menuName = "Simple Event/Bool Event", fileName = "Bool Event ")]
    public class BoolEventChannelSO : ScriptableObject
    {
        public event UnityAction<bool> Event;

        public void Raise(bool param)
        {
            Event?.Invoke(param);
        }
    }
}