using UnityEngine;
using UnityEngine.UI;

public class UICoinsCount : MonoBehaviour
{
    [SerializeField] private Text m_CoinCountText;
    [SerializeField] private CoinStorage m_CoinStorage;
    private void Start()
    {
        if (m_CoinStorage != null)
        {
            m_CoinStorage.CoinsCountUpdateEvent += UpdateCoinsCount;
        }
    }
    private void OnDestroy()
    {
        if (m_CoinStorage != null)
        {
            m_CoinStorage.CoinsCountUpdateEvent -= UpdateCoinsCount;
        }
    }
    public void UpdateCoinsCount(int coinsCount)
    {
        if (m_CoinCountText != null)
        {
            m_CoinCountText.text = coinsCount.ToString();
        }
            
    }
}
