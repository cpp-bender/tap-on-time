using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class EndMenu : BaseMenu
    {
        [Header("DEPENDENCIES - COMMON")]
        [SerializeField] RectTransform background1;
        [SerializeField] RectTransform background2;
        [SerializeField] RectTransform yourScoreText;
        [SerializeField] RectTransform congratzText;
        [SerializeField] RectTransform scoreText;
        [SerializeField] RectTransform cuteEmoji;

        [Header("DEPENDENCIES - MULTIPLE BAR")]
        [SerializeField] RectTransform indicator;
        [SerializeField] RectTransform multiplesParent;

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
            //TODO:Hanle this
        }
    }
}