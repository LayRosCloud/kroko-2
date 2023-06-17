using System;

public class PlayerEvents
{
    public Action JumpEvent;
    public Action DeathEvent;
    public Action LeftMoveEvent;
    public Action RightMoveEvent;

    public static PlayerEvents Instance { get; } = new PlayerEvents();
}
