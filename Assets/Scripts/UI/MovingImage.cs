using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class MovingImage : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] float range;

        [Header("DEBUG")]
        [SerializeField, Range(0f, 1f)] float t = 0f;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO makeProgressEvent;
        [SerializeField] VoidEventChannelSO gameInitEvent;

        private void OnEnable()
        {
            makeProgressEvent.Event += MakeProgress;
            gameInitEvent.Event += Init;
        }

        private void Init()
        {
            float y = transform.localPosition.y;
            float z = transform.localPosition.z;
            transform.localPosition = new Vector3(-range, y, z);
        }

        private void OnDisable()
        {
            makeProgressEvent.Event -= MakeProgress;
            gameInitEvent.Event -= Init;
        }

        private void MakeProgress()
        {
            t += .1f;
            float x = Mathf.Lerp(-range, range, t);
            float y = transform.localPosition.y;
            float z = transform.localPosition.z;
            transform.localPosition = new Vector3(x, y, z);
        }
    }
}
