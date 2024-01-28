using System.Collections.Generic;
using System.Collections;
using DG.Tweening;
using SimpleEvent;
using UnityEngine;
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

        [Header("DEPENDENCIES - CIRCULAR BAR")]
        [SerializeField] RectTransform wholeCircle;
        [SerializeField] List<RectTransform> circularParts;

        [Header("DEPENDENCIES - Arrow")]
        [SerializeField] Arrow arrow;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameInitEvent;
        [SerializeField] VoidEventChannelSO gameStartEvent;
        [SerializeField] VoidEventChannelSO checkEvent;

        [Header("DEBUG")]
        [SerializeField] int oldIndex = -1;
        [SerializeField] CirclePart currentCircularPart;

        public VoidEventChannelSO testEvent;

        private void OnEnable()
        {
            gameInitEvent.Event += OnGameInit;
            gameStartEvent.Event += OnGameStarted;
            checkEvent.Event += OnTap;
            testEvent.Event += OnTestEventTriggered;
        }

        private void OnDisable()
        {
            gameInitEvent.Event -= OnGameInit;
            gameStartEvent.Event -= OnGameStarted;
            checkEvent.Event -= OnTap;
            testEvent.Event -= OnTestEventTriggered;
        }

        private void OnTestEventTriggered()
        {
            var tr = currentPoint.GetComponent<RectTransform>();

            tr.DOScale(Vector3.one * 5f, .25f).SetRelative(true).SetLoops(2, LoopType.Yoyo).Play();
        }

        private void OnTap()
        {
            currentCircularPart.Check(arrow.T);
        }

        private void OnGameInit()
        {
            StartCoroutine(arrow.RotateRoutine());
        }

        private void OnGameStarted()
        {
            DOTween.To(x => group.alpha = x, 0f, 1f, .5f);
            StartCoroutine(RandomizeCircularParts());
        }

        private IEnumerator RandomizeCircularParts()
        {
            while (true)
            {
                int currentIndex;
                do
                {
                    for (int i = 0; i < 4; i++)
                    {
                        circularParts[i].gameObject.SetActive(false);
                    }
                    currentIndex = Random.Range(0, circularParts.Count);
                } while (oldIndex == currentIndex);

                circularParts[currentIndex].gameObject.SetActive(true);
                currentCircularPart = circularParts[currentIndex].GetComponent<CirclePart>();
                oldIndex = currentIndex;

                yield return new WaitForSeconds(1f);
            }
        }
    }
}