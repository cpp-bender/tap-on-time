using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class EndMenu : BaseMenu
    {
        [Header("DEPENDENCIES - COMMON")]
        public RectTransform background0;
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
            Set(background0.gameObject, false);
            Set(background1.gameObject, false);
            Set(background2.gameObject, false);
            Set(yourScoreText.gameObject, false);
            Set(congratzText.gameObject, false);
            Set(scoreText.gameObject, false);
            Set(cuteEmoji.gameObject, false);
            
            Set(indicator.gameObject, false);
            Set(multiplesParent.gameObject, false);
        }

        private void OnGameStarted()
        {
            //TODO:Hanle this
        }
    }
}