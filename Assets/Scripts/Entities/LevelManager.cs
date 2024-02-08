using System.Collections.Generic;
using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    [DefaultExecutionOrder(-99)]
    public class LevelManager : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] List<Level> levels;
        [SerializeField ] FloatEventChannelSO levelInitEvent;

        [Header("DEBUG")]
        [SerializeField] Level currentLevel;

        private void Start()
        {
            currentLevel = levels[0];
            levelInitEvent.Raise(currentLevel.Index);
        }
    }
}
