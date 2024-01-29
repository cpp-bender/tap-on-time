using UnityEngine;
using DG.Tweening;
using TMPro;

namespace TapOnTime
{
    public class LevelProgressBar : MonoBehaviour
    {
        [Header("DEPENDENCIES")]
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] TextMeshProUGUI currentLevelText;
        [SerializeField] TextMeshProUGUI nextLevelText;
        [SerializeField] RectTransform outlineImage;
        [SerializeField] RectTransform fillImage;
        [SerializeField] RectTransform movingImage;

        public void Fade(float f, float t)
        {
            DOTween.To(() => canvasGroup.alpha, x => canvasGroup.alpha = x, f, t).Play();
        }
    }
}