using DG.Tweening;
using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class RotatingArrowMenu : MonoBehaviour
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

        }

        private void OnGameStarted()
        {
            StartCoroutine(arrow.RotateRoutine());
        }
    }
}