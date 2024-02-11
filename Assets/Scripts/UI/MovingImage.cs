using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class MovingImage : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] float range;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameInitEvent;

        private void Init()
        {
            float y = transform.localPosition.y;
            float z = transform.localPosition.z;
            transform.localPosition = new Vector3(-range, y, z);
        }

        private void OnEnable()
        {
            gameInitEvent.Event += Init;
        }

        private void OnDisable()
        {
            gameInitEvent.Event -= Init;
        }

        public void MakeProgress(float t)
        {
            float x = Mathf.Lerp(-range, range, t);
            float y = transform.localPosition.y;
            float z = transform.localPosition.z;
            transform.localPosition = new Vector3(x, y, z);
        }
    }
}
