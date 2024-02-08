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
        [SerializeField] TextMeshProUGUI levelText;
        [SerializeField] RectTransform tapToPlayText;
        [SerializeField] RectTransform playImage;

        [Header("DEPENDENCIES - KEY BAR")]
        [SerializeField] RectTransform[] keys;

        [Header("DEPENDENCIES - GEM BAR")]
        [SerializeField] RectTransform gemCount;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameInitEvent;
        [SerializeField] VoidEventChannelSO gameStartEvent;
        [SerializeField] FloatEventChannelSO levelInitEvent;

        private void OnEnable()
        {
            gameInitEvent.Event += OnGameInit;
            gameStartEvent.Event += OnGameStarted;
            levelInitEvent.Event += OnLevelInit;
        }

        private void OnDisable()
        {
            gameStartEvent.Event -= OnGameStarted;
            gameInitEvent.Event -= OnGameInit;
            levelInitEvent.Event -= OnLevelInit;
        }

        private void OnGameInit()
        {
            TweenPlayImage();
            TweenTapToPlayText();
        }

        private void OnGameStarted()
        {
            Fade();
            levelText.gameObject.SetActive(false);
        }

        private void OnLevelInit(float arg)
        {
            //TODO: Use stringbuilder later on
            levelText.text = "Level " + arg.ToString();
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