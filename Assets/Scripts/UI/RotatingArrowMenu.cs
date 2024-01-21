using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class RotatingArrowMenu : BaseMenu
    {
        [Header("DEPENDENCIES")]
        [SerializeField] RectTransform target;
        [SerializeField] RectTransform arrow;

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

        }
    }
}