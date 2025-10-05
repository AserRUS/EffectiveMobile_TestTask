using UnityEngine;

public class CollectibleItems : MonoBehaviour
{
    [SerializeField] private int m_Value;

    public int GetValue()
    {
        return m_Value;
    }

    public void PickUp()
    {
        gameObject.SetActive(false);
    }
}
