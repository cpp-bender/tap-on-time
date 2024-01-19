using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class RotatingArrowMenu : BaseMenu
    {
        [Header("DEPENDENCIES")]
        public RectTransform background;
        public RectTransform target;
        public RectTransform arrow;

        [Header("EVENTS")]
        public VoidEventChannelSO gameInitEvent;
        public VoidEventChannelSO gameStartEvent;

        private void OnGameInit()
        {
            Set(background.gameObject, true);
            Set(target.gameObject, true);
            Set(arrow.gameObject, true);
        }

        private void OnGameStarted()
        {
            //TODO: Handle this
        }

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
    }
}