using System;
using UnityEngine.Events;

public class PlayerEvents
{
    public UnityEvent JumpEvent =new UnityEvent();
    public UnityEvent DeathEvent = new UnityEvent();

    public UnityEvent MoveEvent = new UnityEvent();

    public static PlayerEvents Instance { get; } = new PlayerEvents();
}
