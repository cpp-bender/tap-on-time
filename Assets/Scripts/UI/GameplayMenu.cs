using SimpleEvent;
using UnityEngine;
using TMPro;

namespace TapOnTime
{
    public class GameplayMenu : MonoBehaviour
    {
        [Header("DEPENDENCIES - COMMON")]
        public RectTransform background;
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
            //TODO:Handle this
        }

        private void OnGameStarted()
        {
            //TODO:Hanle this
        }
    }
}