using UnityEngine;
using SimpleEvent;
using DG.Tweening;
using TMPro;

namespace TapOnTime
{
    public class MainMenu : BaseMenu
    {
        [Header("DEPENDENCIES - COMMON")]
        [SerializeField] RectTransform settings;
        [SerializeField] RectTransform levelText;
        [SerializeField] RectTransform tapToPlayText;
        [SerializeField] RectTransform playImage;

        [Header("DEPENDENCIES - KEY BAR")]
        [SerializeField] RectTransform[] keys;

        [Header("DEPENDENCIES - GEM BAR")]
        [SerializeField] RectTransform gemCount;

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
            gameStartEvent.Event -= OnGameStarted;
            gameInitEvent.Event -= OnGameInit;
        }

        private void OnGameInit()
        {
            TweenPlayImage();
            TweenTapToPlayText();
        }

        private void OnGameStarted()
        {
            Fade();
        }

        private void Fade()
        {
            var cg0 = tapToPlayText.GetComponent<CanvasGroup>();
            var cg1 = playImage.GetComponent<CanvasGroup>();

            DOTween.To(x => cg0.alpha = x, 1f, 0f, .75f).Play();
            DOTween.Kill(playImage);
            playImage.DOScale(Vector3.zero, .25f).Play();
        }

        private void TweenPlayImage()
        {
            playImage.DOScale(Vector3.one * 1.5f, .5f)
                .SetEase(Ease.OutQuad)
                .SetLoops(-1, LoopType.Yoyo)
                .SetRelative(true)
                .Play();
        }

        private void TweenTapToPlayText()
        {
            var text = tapToPlayText.GetComponent<TextMeshProUGUI>();
            DOTween.To(x => text.alpha = x, .5f, 1f, .75f).SetLoops(-1, LoopType.Yoyo).Play();
        }
    }
}