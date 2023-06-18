
using System;

public class ShopEvents
{
    public Action BuyEvent;
    public Action SelectEvent;

    public static ShopEvents Instance { get; } = new ShopEvents();
}
