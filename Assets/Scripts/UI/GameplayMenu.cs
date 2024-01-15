using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class GameplayMenu : MonoBehaviour
    {
        [Header("EVENTS")]
        public VoidEventChannelSO gameStartEvent;
        public VoidEventChannelSO gameInitEvent;

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
