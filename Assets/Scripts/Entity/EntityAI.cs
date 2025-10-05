using UnityEngine;

public class EntityAI : MonoBehaviour
{
    [SerializeField] private EntityMovementController m_MovementController;
    [SerializeField] private Transform[] m_PathPoints;
    [SerializeField] private float m_StepError;
    [SerializeField] private Destructible m_Destructible;
    [SerializeField] private TurnController m_TurnController;
    [SerializeField] private EntitySoundController m_EntitySoundController;

    private int pathPointsIndex;
    private float distanceToPoint;
    private void Start()
    {
        SetDirection();

        if (m_Destructible != null)
        {
            m_Destructible.DeathEvent += Death;
            if (m_EntitySoundController != null)
            {
                m_Destructible.ApplyDamageEvent += m_EntitySoundController.DamageSound;
            }
        }
    }
    private void OnDestroy()
    {
        if (m_Destructible != null)
        {
            m_Destructible.DeathEvent -= Death;
            if (m_EntitySoundController != null)
            {
                m_Destructible.ApplyDamageEvent -= m_EntitySoundController.DamageSound;
            }
        }
    }
    private void Update()
    {
        CheckDistanceToPoint();
    }
    private void CheckDistanceToPoint()
    {
        distanceToPoint = Mathf.Abs(transform.position.x - m_PathPoints[pathPointsIndex].transform.position.x);
        if (distanceToPoint <= m_StepError)
        {
            pathPointsIndex++;
            if (pathPointsIndex == m_PathPoints.Length)
            {
                pathPointsIndex = 0;
            }
            SetDirection();
        }
    }

    private void SetDirection()
    {
        if (m_PathPoints[pathPointsIndex].transform.position.x < transform.position.x)
        {
            if (m_MovementController != null)
            {
                m_MovementController.SetDirection(-1);
            }
            if (m_TurnController != null)
            {
                m_TurnController.Turn(-1);
            }
                
        }
        else
        {
            if (m_MovementController != null)
            {
                m_MovementController.SetDirection(1);
            }
            if (m_TurnController != null)
            {
                m_TurnController.Turn(1);
            }
                
        }
    }
    private void Death()
    {
        gameObject.SetActive(false);
    }
}
