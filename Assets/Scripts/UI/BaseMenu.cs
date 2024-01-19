using DG.Tweening;
using UnityEngine;

namespace TapOnTime
{
    public abstract class BaseMenu : MonoBehaviour
    {
        protected void Set(GameObject go, bool on)
        {
            go.SetActive(on);
        }

        protected void DoSmoothFade(float fStart, float fEnd, float t)
        {
            DOTween.To(x => fStart = x, fStart, fEnd, t).Play();
        }
    }
}
