using UnityEngine.UI;
using UnityEngine;
using SimpleEvent;

namespace TapOnTime
{
    public class FillImage : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] Image image;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO makeProgressEvent;

        [Header("DEBUG")]
        [SerializeField] float t = 0f;

        private void Start()
        {
            image.fillAmount = t;
        }

        private void OnEnable()
        {
            makeProgressEvent.Event += MakeProgress;
        }

        private void OnDisable()
        {
            makeProgressEvent.Event -= MakeProgress;
        }

        private void MakeProgress()
        {
            t += .1f;
            image.fillAmount = t;
        }
    }
}
