using UnityEngine.Events;
using UnityEngine;

namespace SimpleEvent
{
    [CreateAssetMenu(menuName ="Simple Event/Vector3 Event", fileName ="Vector3 Event")]
    public class Vector3EventChannelSO : ScriptableObject
    {
        public event UnityAction<Vector3> Event;

        public void Raise(Vector3 pos)
        {
            Event?.Invoke(pos);
        }
    }
}