using UnityEngine;

namespace TapOnTime
{
    public abstract class BaseMenu : MonoBehaviour
    {
        protected void Set(GameObject go, bool on)
        {
            go.SetActive(on);
        }
    }
}
