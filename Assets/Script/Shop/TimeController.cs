using UnityEngine;

public class TimeController : MonoBehaviour
{
    private void Start()
    {
        PlayerEvents.Instance.RightMoveEvent += SetOne;
        PlayerEvents.Instance.LeftMoveEvent += SetOne;
    }

    private void OnDestroy()
    {
        PlayerEvents.Instance.LeftMoveEvent -= SetOne;
        PlayerEvents.Instance.RightMoveEvent -= SetOne;
    }

    private void SetOne()
    {
        Time.timeScale = 1;
    }
}
