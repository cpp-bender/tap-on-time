using System.Collections;
using SimpleEvent;
using UnityEngine;

namespace TapOnTime
{
    public class Arrow : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] GameObject target;
        [SerializeField] ArrowRotatingData rotatingData;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameStartEvent;
        [SerializeField] VoidEventChannelSO gameInitEvent;
        [SerializeField] VoidEventChannelSO tapSuccessEvent;

        [Header("DEBUG")]
        [SerializeField] float t;

        private float speed;
        private float speedFactor;

        public float T { get => t; }

        private void OnEnable()
        {
            gameStartEvent.Event += OnGameStarted;
            gameInitEvent.Event += OnGameInit;
            tapSuccessEvent.Event += () => speed += speedFactor;
        }

        private void OnDisable()
        {
            gameStartEvent.Event -= OnGameStarted;
            gameInitEvent.Event -= OnGameInit;
            tapSuccessEvent.Event -= () => speed += speedFactor;
        }

        private void OnGameInit()
        {
            StartCoroutine(RotateRoutine());
        }

        private void OnGameStarted()
        {
            speed = 5f;
        }

        public IEnumerator RotateRoutine()
        {
            float m = rotatingData.Dist;
            speed = rotatingData.Speed;
            speedFactor = rotatingData.T;

            while (true)
            {
                if (t >= .9999f)
                {
                    t = 0f;
                }
                t += .1f * Time.deltaTime * speed;
                float ang = (float)T * SimpleMath.TAU;
                float x = Mathf.Cos(-ang) * m;
                float y = Mathf.Sin(-ang) * m;
                transform.position = target.transform.TransformPoint(new Vector3(x, y, transform.position.z));
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (float)t * -360f + -90);
                yield return null;
            }
        }
    }
}
