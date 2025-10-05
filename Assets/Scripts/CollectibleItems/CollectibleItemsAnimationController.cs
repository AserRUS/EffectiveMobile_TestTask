using UnityEngine;

public class CollectibleItemsAnimationController : MonoBehaviour
{
    [SerializeField] private Transform m_Visual;
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_Amplitude;

    private Vector2 newPos;

    private void Start()
    {
        newPos.x = transform.position.x;
    }

    private void Update()
    {
        CollectibleItemsAnimation();
    }

    private void CollectibleItemsAnimation()
    {
        newPos.y = transform.position.y + Mathf.Sin(Time.time * m_Speed) * m_Amplitude;
        m_Visual.position = newPos;
    }
}
