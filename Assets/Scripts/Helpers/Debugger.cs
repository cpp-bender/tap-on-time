using UnityEngine;
using SimpleEvent;

namespace CPPBENDER
{
    [DefaultExecutionOrder(-99)]
    public class Debugger : MonoBehaviour
    {
        [Header("EVENTS")]
        public VoidEventChannelSO gameStartEvent;
        public VoidEventChannelSO gameInitEvent;

        private void OnEnable()
        {
            gameInitEvent.Event += OnGameInit;
            gameStartEvent.Event += OnGameStart;
        }

        private void OnGameInit()
        {
            Debug.Log("Game Init!");
        }

        private void OnGameStart()
        {
            Debug.Log("Game Started!");
        }
    }
}