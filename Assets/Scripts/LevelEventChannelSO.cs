using UnityEngine.Events;
using UnityEngine;
using TapOnTime;

namespace SimpleEvent
{
    [CreateAssetMenu(menuName = "Simple Event/Custom/Level Event", fileName = "Level Event")]
    public class LevelEventChannelSO : ScriptableObject
    {
        public event UnityAction<Level> Event;

        public void Raise(Level level)
        {
            Event?.Invoke(level);
        }
    }
}
