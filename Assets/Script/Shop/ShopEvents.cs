
using System;
using UnityEngine.Events;

public class ShopEvents
{
    public UnityEvent BuyEvent = new UnityEvent();
    public UnityEvent SelectEvent = new UnityEvent();

    public static ShopEvents Instance { get; } = new ShopEvents();
}
