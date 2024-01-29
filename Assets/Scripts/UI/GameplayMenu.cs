using System.Collections.Generic;
using System.Collections;
using SimpleEvent;
using UnityEngine;
using TMPro;

namespace TapOnTime
{
    public class GameplayMenu : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] TextMeshProUGUI currentLevelText;
        [SerializeField] TextMeshProUGUI nextLevelText;
        [SerializeField] PointBar pointBar;
        [SerializeField] LevelProgressBar progressBar;
        [SerializeField] RectTransform wholeCircle;
        [SerializeField] Arrow arrow;
        [SerializeField] List<RectTransform> circularParts;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameInitEvent;
        [SerializeField] VoidEventChannelSO gameStartEvent;
        [SerializeField] VoidEventChannelSO checkEvent;

        [Header("DEBUG")]
        [SerializeField] int oldIndex = 0;
        [SerializeField] CirclePart currentCircularPart;

        private void OnEnable()
        {
            gameInitEvent.Event += OnGameInit;
            gameStartEvent.Event += OnGameStarted;
            checkEvent.Event += OnTap;
        }

        private void OnDisable()
        {
            gameInitEvent.Event -= OnGameInit;
            gameStartEvent.Event -= OnGameStarted;
            checkEvent.Event -= OnTap;
        }

        private void OnTap()
        {
            currentCircularPart.Check(arrow.T);
        }

        private void OnGameInit()
        {
            StartCoroutine(arrow.RotateRoutine());
            circularParts[0].gameObject.SetActive(true);
            currentCircularPart = circularParts[0].GetComponent<CirclePart>();

            pointBar.Fade(0f, .1f);
            progressBar.Fade(0f,.1f);
        }

        private void OnGameStarted()
        {
            StartCoroutine(RandomizeCircularParts());
            
            pointBar.Fade(1f, 1f);
            progressBar.Fade(1f, 1f);
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

        private void Set(GameObject go, bool on)
        {
            go.SetActive(on);
        }
    }
}