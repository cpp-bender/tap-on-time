using System.Collections;
using UnityEngine;
using SimpleEvent;
using DG.Tweening;
using CPPBENDER;

namespace TapOnTime
{
    [DefaultExecutionOrder(-100)]
    public class GameManager : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] VoidEventChannelSO gameInitEvent;
        [SerializeField] VoidEventChannelSO gameStartEvent;
        [SerializeField] VoidEventChannelSO checkEvent;

        private bool gameStarted = false;

        private IEnumerator Start()
        {
            Application.targetFrameRate = 60;
            gameInitEvent?.Raise();
            yield return new WaitForMouseDown();
            gameStartEvent?.Raise();
            gameStarted = true;
            DOTween.Init();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && gameStarted)
            {
                checkEvent?.Raise();
            }
        }
    }
}