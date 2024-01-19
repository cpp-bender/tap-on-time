using UnityEngine;
using SimpleEvent;

namespace TapOnTime
{
    public class MainMenu : BaseMenu
    {
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
            Set(backgroundMain.gameObject, true);
            Set(settings.gameObject, true);
            Set(levelText.gameObject, true);
            Set(tapToPlayText.gameObject, true);
            Set(playImage.gameObject, true);

            Set(keys[0].gameObject, true);
            Set(keys[1].gameObject, true);
            Set(keys[2].gameObject, true);

            Set(gemCount.gameObject, true);
        }

        private void OnGameStarted()
        {

        }
    }
}