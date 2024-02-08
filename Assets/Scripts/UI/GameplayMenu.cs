using System.Collections.Generic;
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
        [SerializeField] List<RectTransform> circleParts;
        [SerializeField] Arrow arrow;
        [SerializeField] FillImage fillImage;
        [SerializeField] MovingImage movingImage;
        [SerializeField] TextMeshProUGUI targetScoreText;
        [SerializeField] TextMeshProUGUI currentScoreText;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameInitEvent;
        [SerializeField] VoidEventChannelSO gameStartEvent;
        [SerializeField] VoidEventChannelSO checkEvent;
        [SerializeField] VoidEventChannelSO makeProgressEvent;
        [SerializeField] LevelEventChannelSO levelInitEvent;
        [SerializeField] IntEventChannelSO addScoreEvent;

        [Header("DEBUG")]
        [SerializeField] int oldIndex = 0;
        [SerializeField] CirclePart currentCirclePart;
        [SerializeField] float t = 0f;
        [SerializeField] int currentScore;
        [SerializeField] int targetScore;

        private void OnEnable()
        {
            gameInitEvent.Event += OnGameInit;
            gameStartEvent.Event += OnGameStarted;
            checkEvent.Event += OnTap;
            makeProgressEvent.Event += ChangeCirclePart;
            levelInitEvent.Event += OnLevelInit;
            addScoreEvent.Event += AddScore;
        }

        private void OnDisable()
        {
            gameInitEvent.Event -= OnGameInit;
            gameStartEvent.Event -= OnGameStarted;
            checkEvent.Event -= OnTap;
            makeProgressEvent.Event -= ChangeCirclePart;
            levelInitEvent.Event -= OnLevelInit;
            addScoreEvent.Event -= AddScore;
        }

        private void AddScore(int arg)
        {
            currentScoreText.text = (currentScore + arg).ToString();
            currentScore += arg;
        }

        private void OnTap()
        {
            currentCirclePart.Check(arrow.T);
        }

        private void OnLevelInit(Level level)
        {
            currentLevelText.text = "Level " + level.Index.ToString();
            nextLevelText.text = "Level " + (level.Index + 1).ToString();
            targetScoreText.text = level.Score.ToString();
        }

        private void OnGameInit()
        {
            circleParts[0].gameObject.SetActive(true);
            currentCirclePart = circleParts[0].GetComponent<CirclePart>();

            pointBar.Fade(0f, .1f);
            progressBar.Fade(0f, .1f);
        }

        private void OnGameStarted()
        {
            ChangeCirclePart();
            pointBar.Fade(1f, 1f);
            progressBar.Fade(1f, 1f);
        }

        private void ChangeCirclePart()
        {
            int currentIndex;
            do
            {
                for (int i = 0; i < 4; i++)
                {
                    circleParts[i].gameObject.SetActive(false);
                }
                currentIndex = Random.Range(0, circleParts.Count);
            } while (oldIndex == currentIndex);

            circleParts[currentIndex].gameObject.SetActive(true);
            currentCirclePart = circleParts[currentIndex].GetComponent<CirclePart>();
            oldIndex = currentIndex;
        }
    }
}