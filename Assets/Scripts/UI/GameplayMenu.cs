using SimpleEvent;
using UnityEngine;
using TMPro;

namespace TapOnTime
{
    public class GameplayMenu : MonoBehaviour, ICommon
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
            Set(background.gameObject, false);
            Set(currentLevelText.gameObject, false);
            Set(nextLevelText.gameObject, false);

            Set(currentPoint.gameObject, false); 
            Set(targetText.gameObject, false);
            Set(targetPoint.gameObject, false);
            
            Set(outlineImage.gameObject, false);
            Set(fillImage.gameObject, false);
            Set(movingImage.gameObject, false);
        }

        private void OnGameStarted()
        {
            //TODO:Hanle this
        }

        public void Set(GameObject go, bool on)
        {
            go.SetActive(on);
        }
    }
}