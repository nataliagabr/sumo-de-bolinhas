using System;

public static class PlayerOM
{
    public static Action<int> OnCoinCollected;

    public static void CollectCoin(int amount)
    {
        OnCoinCollected?.Invoke(amount);
    }
}
