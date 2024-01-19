using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class EndMenu : BaseMenu
    {
        [Header("COMPONENTS")]
        public CanvasGroup group;

        [Header("DEPENDENCIES - COMMON")]
        public RectTransform background1;
        public RectTransform background2;
        public RectTransform yourScoreText;
        public RectTransform congratzText;
        public RectTransform scoreText;
        public RectTransform cuteEmoji;

        [Header("DEPENDENCIES - MULTIPLE BAR")]
        public RectTransform indicator;
        public RectTransform multiplesParent;

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
            group.alpha = 0f;
        }

        private void OnGameStarted()
        {
            //TODO:Hanle this
        }
    }
}