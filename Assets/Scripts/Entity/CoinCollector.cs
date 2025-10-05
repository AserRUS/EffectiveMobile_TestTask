using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    public event UnityAction PickUpEvent;

    [SerializeField] private CoinStorage m_CoinStorage;

    private Coin coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        coin = collision.transform.GetComponent<Coin>();
        if (coin != null)
        {
            coin.PickUp();
            PickUpEvent?.Invoke();
            if (m_CoinStorage != null)
            {
                m_CoinStorage.AddCoins(coin.GetValue());
            }
        }
    }
}
