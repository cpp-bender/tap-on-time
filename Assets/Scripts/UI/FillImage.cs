using UnityEngine.UI;
using UnityEngine;

namespace TapOnTime
{
    public class FillImage : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] Image image;

        private void Start()
        {
            image.fillAmount = 0f;
        }

        public void MakeProgress(float t)
        {
            image.fillAmount = t;
        }
    }
}
