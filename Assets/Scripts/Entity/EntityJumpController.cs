using UnityEngine;
using UnityEngine.Events;

public class EntityJumpController : MonoBehaviour
{
    public event UnityAction JumpEvent;

    [SerializeField] private Rigidbody2D m_Rigidbody;
    [SerializeField] private GroundDetector m_GroundDetector;
    [SerializeField] private float m_JumpForce;
    [SerializeField] private int m_MaxExtraJumpCount;

    private Vector2 velocity;
    private int extraJumpCount;

    private void Start()
    {
        extraJumpCount = m_MaxExtraJumpCount;
        if (m_GroundDetector != null)
        {
            m_GroundDetector.OnGroundEvent += RestoringExtraJumpCount;
        }
        
    }
    private void OnDestroy()
    {
        if (m_GroundDetector != null)
        {
            m_GroundDetector.OnGroundEvent -= RestoringExtraJumpCount;
        }
    }

    public void TryJump()
    {
        if (m_Rigidbody == null || m_GroundDetector == null)
        {
            return;
        }

        if (m_GroundDetector.OnGround == true)
        {
            Jump();
        }
        else
        {
            if (extraJumpCount > 0)
            {
                Jump();
                extraJumpCount--;
            }
        }
    }

    private void RestoringExtraJumpCount()
    {
        extraJumpCount = m_MaxExtraJumpCount;
    }
    public void Jump()
    {
        velocity.x = m_Rigidbody.velocity.x;
        m_Rigidbody.velocity = velocity;
        m_Rigidbody.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
        JumpEvent?.Invoke();
    }
}
