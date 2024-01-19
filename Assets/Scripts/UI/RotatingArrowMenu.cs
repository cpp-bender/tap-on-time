using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class RotatingArrowMenu : BaseMenu
    {
        [Header("DEPENDENCIES")]
        public RectTransform target;
        public RectTransform arrow;

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

        }

        private void OnGameStarted()
        {

        }
    }
}