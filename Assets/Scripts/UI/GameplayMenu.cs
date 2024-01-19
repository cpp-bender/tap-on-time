using SimpleEvent;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace TapOnTime
{
    public class GameplayMenu : BaseMenu
    {
        [Header("DEPENDENCIES - COMMON")]
        public TextMeshProUGUI currentLevelText;
        public TextMeshProUGUI nextLevelText;

        [Header("DEPENDENCIES - POINT BAR")]
        public TextMeshProUGUI currentPoint;
        public TextMeshProUGUI targetText;
        public TextMeshProUGUI targetPoint;

        [Header("DEPENDENCIES - LEVEL PROGRESS BAR")]
        public RectTransform outlineImage;
        public RectTransform fillImage;
        public RectTransform movingImage;

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
            GetComponent<CanvasGroup>().alpha = 0f;
        }

        private void OnGameStarted()
        {
            DOTween.To(x => GetComponent<CanvasGroup>().alpha = x, 0f, 1f, .5f);
        }
    }
}