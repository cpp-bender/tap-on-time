using UnityEngine;
using SimpleEvent;
using DG.Tweening;

namespace TapOnTime
{
    public class MainMenu : BaseMenu
    {
        [Header("DEPENDENCIES - COMMON")]
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
            StartPlayImageAnimation();
        }

        private void OnGameStarted()
        {

        }

        private void StartPlayImageAnimation()
        {
            playImage.DOScale(Vector3.one * 1.5f, .5f)
                .SetEase(Ease.OutQuad)
                .SetLoops(-1, LoopType.Yoyo)
                .SetRelative(true)
                .Play();
        }
    }
}