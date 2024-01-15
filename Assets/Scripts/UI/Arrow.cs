using System.Collections;
using UnityEngine;

namespace TapOnTime
{
    public class Arrow : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        public GameObject target;
        public ArrowRotatingData rotatingData;

        private Vector3 rotatingDir;
        private float rotatingSpeed;

        private IEnumerator Start()
        {
            InitRotatingParams();
            StartCoroutine(StartRotating());
            yield return null;
        }

        private void InitRotatingParams()
        {
            rotatingSpeed = rotatingData.RotatingSpeed;
            rotatingDir = rotatingData.RotatingDir;
        }

        private IEnumerator StartRotating()
        {
            while (true)
            {
                transform.RotateAround((target.transform.position), rotatingDir, rotatingSpeed* Time.deltaTime);
                yield return null;
            }
        }

        private void StopRotating()
        {
            rotatingSpeed = 0f;
        }
    }
}
