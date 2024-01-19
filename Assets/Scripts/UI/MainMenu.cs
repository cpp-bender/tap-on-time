using UnityEngine;
using SimpleEvent;

namespace TapOnTime
{
    public class MainMenu : BaseMenu
    {
        [Header("COMPONENTS")]
        public CanvasGroup group;

        [Header("DEPENDENCIES - COMMON")]
        public RectTransform backgroundMain;
        public RectTransform settings;
        public RectTransform levelText;
        public RectTransform tapToPlayText;
        public RectTransform playImage;

        [Header("DEPENDENCIES - KEY BAR")]
        public RectTransform[] keys;

        [Header("DEPENDENCIES - GEM BAR")]
        public RectTransform gemCount;

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
            gameStartEvent.Event -= OnGameStarted;
            gameInitEvent.Event -= OnGameInit;
        }

        private void OnGameInit()
        {
            group.alpha = 1f;
        }

        private void OnGameStarted()
        {

        }
    }
}