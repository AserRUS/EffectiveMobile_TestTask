using UnityEngine;
using UnityEngine.Events;

public class CoinStorage : MonoBehaviour
{
    public event UnityAction<int> CoinsCountUpdateEvent;
    private int coinCount;
    public void AddCoins(int count)
    {
        coinCount += count;
        CoinsCountUpdateEvent?.Invoke(coinCount);
    }
}
