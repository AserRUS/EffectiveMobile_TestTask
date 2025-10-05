using UnityEngine;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    public event UnityAction ApplyDamageEvent;
    public event UnityAction DeathEvent;
    public event UnityAction RestoringHealthEvent;
    public int CurrentHealthPoints => currentHealthPoints;
    public int MaxHealthPoints => m_MaxHealthPoints;

    [SerializeField] private int m_MaxHealthPoints;

    private int currentHealthPoints;

    private void Start()
    {
        RestoringHealth(m_MaxHealthPoints);
    }

    private void RestoringHealth(int value)
    {
        currentHealthPoints += value;
        RestoringHealthEvent?.Invoke();
        if (currentHealthPoints > m_MaxHealthPoints)
        {
            currentHealthPoints = m_MaxHealthPoints;
        }
    }
    public void ApplyDamage(int value)
    {
        currentHealthPoints -= value;
        ApplyDamageEvent?.Invoke();
        if (currentHealthPoints <= 0)
        {
            currentHealthPoints = 0;
            DeathEvent?.Invoke();
        }        
    }
}
