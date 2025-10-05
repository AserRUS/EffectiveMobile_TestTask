using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private Vector2 m_MovementVector;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(m_MovementVector.normalized * m_Speed * Time.deltaTime);
    }
}
