using UnityEngine;
using UnityEngine.UI;

public class ScrollforTest : MonoBehaviour
{
    [SerializeField] ScrollRect scroll;

    public void ResetScroll()
    {
        scroll.verticalNormalizedPosition = 1f;
    }
}
