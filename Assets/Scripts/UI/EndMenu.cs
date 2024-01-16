using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class EndMenu : MonoBehaviour
    {
        [Header("DEPENDENCIES - COMMON")]
        public RectTransform score;
        public RectTransform cuteEmoji;

        [Header("DEPENDENCIES - MULTIPLE BAR")]
        public RectTransform indicator;

        [Header("EVENTS")]
        public VoidEventChannelSO gameInitEvent;
        public VoidEventChannelSO gameStartEvent;

        private void OnEnable()
        {
            gameInitEvent.Event += OnGameInit;
            gameStartEvent.Event += OnGameStarted;
        }

        private void OnDisable()
        {
            gameInitEvent.Event -= OnGameInit;
            gameStartEvent.Event -= OnGameStarted;
        }

        private void OnGameInit()
        {
            //TODO:Handle this
        }

        private void OnGameStarted()
        {
            //TODO:Hanle this
        }
    }
}
