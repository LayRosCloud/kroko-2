using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMove), typeof(PlayerDeath), typeof(PlayerAudio))]
public class Player : MonoBehaviour
{
    private void Awake()
    {
        QualitySettings.maxQueuedFrames = 0;
        Application.targetFrameRate = 60;
    }
}
