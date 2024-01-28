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

        [Header("DEBUG")]
        [SerializeField,] double t;
        [SerializeField,] float speed;

        [Header("EVENTS")]
        [SerializeField] VoidEventChannelSO gameStartEvent;

        private void OnEnable()
        {
            gameStartEvent.Event += OnGameStarted;
        }

        private void OnDisable()
        {
            gameStartEvent.Event -= OnGameStarted;
        }

        private void OnGameStarted()
        {
            speed = 5f;
        }

        public double T { get => t; }

        public IEnumerator RotateRoutine()
        {
            float m = rotatingData.Dist;
            speed = rotatingData.InitSpeed;

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
