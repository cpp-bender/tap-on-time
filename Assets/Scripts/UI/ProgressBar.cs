using UnityEngine;
using DG.Tweening;

namespace TapOnTime
{
    public class ProgressBar : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] CanvasGroup canvasGroup;

        public void Fade(float f, float t)
        {
            DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, f, t).Play();
        }
    }
}
