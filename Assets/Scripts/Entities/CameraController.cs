using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class CameraController : MonoBehaviour
    {
        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameInitEvent;
        [SerializeField] VoidEventChannelSO gameStartEvent;

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

        }
    }
}
