using System;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerEvents.Instance.MoveEvent.AddListener(SetOne);
    }
    private void SetOne()
    {
        Time.timeScale = 1;
    }
}
