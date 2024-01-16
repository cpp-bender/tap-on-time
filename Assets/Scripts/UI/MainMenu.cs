using UnityEngine;
using SimpleEvent;

namespace TapOnTime
{
    public class MainMenu : MonoBehaviour
    {
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
            gameStartEvent.Event -= OnGameStarted;
            gameInitEvent.Event -= OnGameInit;
        }

        private void OnGameStarted()
        {
            //TODO:Handle this    
        }

        private void OnGameInit()
        {
            //TODO:Handle this
        }
    }
}