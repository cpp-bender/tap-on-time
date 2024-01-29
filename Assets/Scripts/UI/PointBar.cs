using DG.Tweening;
using UnityEngine;

namespace TapOnTime
{
    public class PointBar : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] RectTransform currentPoint;
        [SerializeField] RectTransform targetPoint;
        [SerializeField] RectTransform targetText;

        public void Fade(float f, float t)
        {
            DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, f, t).Play();
        }
    }
}
