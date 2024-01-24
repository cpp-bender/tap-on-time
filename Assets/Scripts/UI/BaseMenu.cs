using UnityEngine;

namespace TapOnTime
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BaseMenu : MonoBehaviour
    {
        [Header("BASE")]
        [SerializeField] protected CanvasGroup group;
    }
}
