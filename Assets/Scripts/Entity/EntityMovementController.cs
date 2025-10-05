using UnityEngine;

public class EntityMovementController : MonoBehaviour
{   

    [SerializeField] private Rigidbody2D m_Rigidbody;
    [SerializeField] private GroundDetector m_GroundDetector;
    [SerializeField] private float m_Acceleration;
    [SerializeField] private float m_BrakingForce;
    [SerializeField] private float m_MaxSpeed;    

    private Vector2 targetDirection;
    private Vector2 differenceVector;

    private void FixedUpdate()
    {
        if (m_Rigidbody == null)
        {
            return;
        }        

        if (targetDirection.x == 0 || Mathf.Abs(targetDirection.x * m_MaxSpeed) < Mathf.Abs(m_Rigidbody.velocity.x))
        {
            Braking();
        }
        else
        {
            Acceleration();
        }
    }
    private void Braking()
    {
        if (m_Rigidbody.velocity.x == 0)
        {
            return;
        }
        if (m_GroundDetector != null && m_GroundDetector.OnGround == false)
        {
            return;
        }
        differenceVector.x = -m_Rigidbody.velocity.x;

        if (Mathf.Abs(differenceVector.x) <= m_BrakingForce * Time.fixedDeltaTime / m_Rigidbody.mass)
        {            
            m_Rigidbody.AddForce(differenceVector / Time.fixedDeltaTime * m_Rigidbody.mass);
        }
        else
        {
            m_Rigidbody.AddForce(differenceVector.normalized * m_BrakingForce);
        }
    }
    private void Acceleration()
    {
        differenceVector.x = (targetDirection.x * m_MaxSpeed) - m_Rigidbody.velocity.x;

        if (Mathf.Abs(differenceVector.x) <= m_Acceleration * Time.fixedDeltaTime / m_Rigidbody.mass)
        {
            m_Rigidbody.AddForce(differenceVector / Time.fixedDeltaTime * m_Rigidbody.mass);
        }
        else
        {
            m_Rigidbody.AddForce(targetDirection.normalized * m_Acceleration);
        }
    }

    public void SetDirection(int direction)
    {        
        targetDirection.x = direction;
    }

   public Vector2 GetRigidbodyVelocity()
   {
        if (m_Rigidbody != null)
        {
            return m_Rigidbody.velocity;
        }
        else
        {
            return Vector2.zero;
        }
        
   }
}
