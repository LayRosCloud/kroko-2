using UnityEngine;

public class TimeController : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerEvents.Instance.MoveEvent += SetOne;
    }

    private void SetOne()
    {
        Time.timeScale = 1;
    }
}
