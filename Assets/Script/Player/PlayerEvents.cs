using System;

public class PlayerEvents
{
    public Action JumpEvent;
    public Action DeathEvent;

    public Action MoveEvent;

    public static PlayerEvents Instance { get; } = new PlayerEvents();
}
