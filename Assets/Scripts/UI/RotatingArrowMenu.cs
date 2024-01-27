using DG.Tweening;
using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class RotatingArrowMenu : BaseMenu
    {
        [Header("DEPENDENCIES")]
        [SerializeField] RectTransform target;
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
            group.alpha = 0f;
        }

        private void OnGameStarted()
        {
            DOTween.To(x => group.alpha = x, 0f, 1f, .75f).Play();
            StartCoroutine(arrow.RotateRoutine()); 
        }
    }
}