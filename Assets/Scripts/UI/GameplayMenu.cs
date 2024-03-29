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
        [SerializeField] TextMeshProUGUI targetScoreText;
        [SerializeField] TextMeshProUGUI currentScoreText;
        [Space(10f)]

        [SerializeField] PointBar pointBar;
        [SerializeField] ProgressBar progressBar;
        [SerializeField] FillImage fillImage;
        [SerializeField] MovingImage movingImage;
        [SerializeField] Arrow arrow;
        [SerializeField] List<RectTransform> circleParts;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameInitEvent;
        [SerializeField] VoidEventChannelSO gameStartEvent;
        [SerializeField] VoidEventChannelSO checkEvent;
        [SerializeField] LevelEventChannelSO levelInitEvent;
        [SerializeField] VoidEventChannelSO tapSuccessEvent;

        [Header("DEBUG")]
        [SerializeField] float completeRatio;
        [SerializeField] int currentScore;
        [SerializeField] int targetScore;

        private CirclePart currentCirclePart;
        private int tempInt = 0;

        private void OnEnable()
        {
            gameInitEvent.Event += OnGameInit;
            gameStartEvent.Event += OnGameStarted;
            checkEvent.Event += OnTap;
            levelInitEvent.Event += OnLevelInit;
            tapSuccessEvent.Event += ChangeCirclePart;
            tapSuccessEvent.Event += AddScore;
            tapSuccessEvent.Event += HandleProgress;
        }

        private void OnDisable()
        {
            gameInitEvent.Event -= OnGameInit;
            gameStartEvent.Event -= OnGameStarted;
            checkEvent.Event -= OnTap;
            levelInitEvent.Event -= OnLevelInit;
            tapSuccessEvent.Event -= ChangeCirclePart;
            tapSuccessEvent.Event -= AddScore;
            tapSuccessEvent.Event -= HandleProgress;
        }

        private void OnGameInit()
        {
            circleParts[0].gameObject.SetActive(true);
            currentCirclePart = circleParts[0].GetComponent<CirclePart>();

            pointBar.Fade(0f, .1f);
            progressBar.Fade(0f, .1f);
        }

        private void OnLevelInit(Level level)
        {
            currentLevelText.text = "Level " + level.Index.ToString();
            nextLevelText.text = "Level " + (level.Index + 1).ToString();
            targetScoreText.text = level.Score.ToString();
            targetScore = level.Score;
            currentScore = 0;
        }

        private void OnTap()
        {
            currentCirclePart.Check(arrow.T);
        }

        private void OnGameStarted()
        {
            ChangeCirclePart();
            pointBar.Fade(1f, 1f);
            progressBar.Fade(1f, 1f);
        }

        private void AddScore()
        {
            currentScoreText.text = (currentScore + 1).ToString();
            currentScore += 1;
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
            } while (tempInt == currentIndex);

            circleParts[currentIndex].gameObject.SetActive(true);
            currentCirclePart = circleParts[currentIndex].GetComponent<CirclePart>();
            tempInt = currentIndex;
        }

        private void HandleProgress()
        {
            completeRatio = (float)currentScore / (float)targetScore;
            fillImage.MakeProgress(completeRatio);
            movingImage.MakeProgress(completeRatio);
        }
    }
}