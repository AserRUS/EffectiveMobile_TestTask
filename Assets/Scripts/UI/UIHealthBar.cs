using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Destructible m_Destructible;
    [SerializeField] private Slider m_Slider;


    private void Awake()
    {
        if (m_Destructible == null || m_Slider == null)
        {
            return;
        }
        m_Slider.maxValue = m_Destructible.MaxHealthPoints;
        m_Destructible.ApplyDamageEvent += SliderUpdate;
        m_Destructible.RestoringHealthEvent += SliderUpdate;
    }
    private void OnDestroy()
    {
        if (m_Destructible == null || m_Slider == null)
        {
            return;
        }
        
        m_Destructible.ApplyDamageEvent -= SliderUpdate;
        m_Destructible.RestoringHealthEvent -= SliderUpdate;
    }

    private void SliderUpdate()
    {
        m_Slider.value = m_Destructible.CurrentHealthPoints;
    }
}
