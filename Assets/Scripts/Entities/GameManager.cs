using System.Collections;
using UnityEngine;
using SimpleEvent;
using CPPBENDER;

namespace TapOnTime
{
    [DefaultExecutionOrder(-100)]
    public class GameManager : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        public VoidEventChannelSO gameInitEvent;
        public VoidEventChannelSO gameStartEvent;

        private IEnumerator Start()
        {
            gameInitEvent?.Raise();
            yield return new WaitForMouseDown();
            gameStartEvent?.Raise();
        }
    }
}