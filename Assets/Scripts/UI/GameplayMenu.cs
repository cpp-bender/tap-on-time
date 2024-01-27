using SimpleEvent;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace TapOnTime
{
    public class GameplayMenu : BaseMenu
    {
        [Header("DEPENDENCIES - COMMON")]
        [SerializeField] TextMeshProUGUI currentLevelText;
        [SerializeField] TextMeshProUGUI nextLevelText;

        [Header("DEPENDENCIES - POINT BAR")]
        [SerializeField] TextMeshProUGUI currentPoint;
        [SerializeField] TextMeshProUGUI targetText;
        [SerializeField] TextMeshProUGUI targetPoint;

        [Header("DEPENDENCIES - LEVEL PROGRESS BAR")]
        [SerializeField] RectTransform outlineImage;
        [SerializeField] RectTransform fillImage;
        [SerializeField] RectTransform movingImage;

        [Header("DEPENDENCIES - Arrow")]
        [SerializeField] Arrow arrow;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameInitEvent;
        [SerializeField] VoidEventChannelSO gameStartEvent;

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
            StartCoroutine(arrow.RotateRoutine());
        }

        private void OnGameStarted()
        {
            DOTween.To(x => group.alpha = x, 0f, 1f, .5f);
        }
    }
}