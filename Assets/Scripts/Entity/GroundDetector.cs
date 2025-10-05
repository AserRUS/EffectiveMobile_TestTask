using UnityEngine;
using UnityEngine.Events;

public class GroundDetector : MonoBehaviour
{
    public event UnityAction OnGroundEvent;

    public bool OnGround => onGround;

    [SerializeField] private float m_RayDistance;
    [SerializeField] private LayerMask m_LayerMask;

    private bool onGround;
    private RaycastHit2D raycastHit2D;
    private void Update()
    {
        GroundCheck();
    }
    private void GroundCheck()
    {
        raycastHit2D = Physics2D.Raycast(transform.position, -transform.up, m_RayDistance, m_LayerMask);
        if (onGround == false && raycastHit2D == true)
        {
            OnGroundEvent?.Invoke();
        }
        onGround = raycastHit2D;
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, -Vector2.up * m_RayDistance, Color.yellow);
    }
}
