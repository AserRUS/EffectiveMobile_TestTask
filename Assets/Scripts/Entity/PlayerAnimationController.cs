using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{  
    [SerializeField] private Animator m_Animator;
    [SerializeField] private GroundDetector m_GroundDetector;
    [SerializeField] private EntityMovementController m_EntityMovementController;
    

    private void Update()
    {
        SetAnimatorParameters();
    }

    private void SetAnimatorParameters()
    {
        if (m_Animator == null)
        {
            return;
        }

        if (m_EntityMovementController != null)
        {
            m_Animator.SetFloat("VelocityX", Mathf.Abs(m_EntityMovementController.GetRigidbodyVelocity().x));
        }

        if (m_GroundDetector != null)
        {
            m_Animator.SetBool("OnGround", m_GroundDetector.OnGround);
        }
    }
    
}
 