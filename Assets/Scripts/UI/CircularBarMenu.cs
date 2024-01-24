using System.Collections.Generic;
using System.Collections;
using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class CircularBarMenu : BaseMenu
    {
        [Header("DEPENDENCIES")]
        public RectTransform wholePart;
        public List<RectTransform> circularParts;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameInitEvent;
        [SerializeField] VoidEventChannelSO gameStartEvent;

        private int oldIndex = -1;

        private void Start()
        {
            group.alpha = 0f;
        }

        private void OnEnable()
        {
            gameInitEvent.Event += OnGameInit;
            gameStartEvent.Event += OnGameStart;
        }

        private void OnDisable()
        {
            gameInitEvent.Event -= OnGameInit;
            gameStartEvent.Event -= OnGameStart;
        }

        private void OnGameInit()
        {

        }

        private void OnGameStart()
        {
            group.alpha = 1f;
            StartCoroutine(DoStuff());
        }

        private IEnumerator DoStuff()
        {
            //TODO: Cancel this out later on!
            while (true)
            {
                for (int i = 0; i < circularParts.Count; i++)
                {
                    circularParts[i].gameObject.SetActive(false);
                }

                int currentIndex;
                do
                {
                    currentIndex = Random.Range(0, circularParts.Count);
                } while (oldIndex == currentIndex);

                circularParts[currentIndex].gameObject.SetActive(true);

                yield return new WaitForSeconds(1f);
            }
        }
    }
}
