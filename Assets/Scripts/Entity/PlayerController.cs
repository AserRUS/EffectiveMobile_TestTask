using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private EntityMovementController m_MovementController;
    [SerializeField] private InputController m_InputController;
    [SerializeField] private EntityJumpController m_JumpController;
    [SerializeField] private Destructible m_Destructible;
    [SerializeField] private ProjectileSpawner m_ProjectileSpawner;
    [SerializeField] private TurnController m_TurnController;
    [SerializeField] private CoinCollector m_CoinCollector;
    [SerializeField] private EntitySoundController m_PlayerSoundController;

    private void Start()
    {
        if (m_Destructible != null)
        {
            m_Destructible.DeathEvent += Death;
        }

        if (m_PlayerSoundController != null)
        {
            if (m_Destructible != null)
            {
                m_Destructible.ApplyDamageEvent += m_PlayerSoundController.DamageSound;
            }
            if (m_JumpController != null)
            {
                m_JumpController.JumpEvent += m_PlayerSoundController.JumpSound;
            }
            if (m_ProjectileSpawner != null)
            {
                m_ProjectileSpawner.SpawnProjectileEvent += m_PlayerSoundController.ShotSound;
            }
            if (m_CoinCollector != null)
            {
                m_CoinCollector.PickUpEvent += m_PlayerSoundController.PickUpSound;
            }
        }

        if (m_InputController != null)
        {
            if (m_MovementController != null)
            {
                m_InputController.DirectionUpdateEvent += m_MovementController.SetDirection;
            }
            if (m_JumpController != null)
            {
                m_InputController.SpacePressedEvent += m_JumpController.TryJump;
            }
            if (m_ProjectileSpawner != null)
            {
                m_InputController.MousePressedEvent += m_ProjectileSpawner.SpawnProjectile;
            }
            if (m_TurnController != null)
            {
                m_InputController.DirectionUpdateEvent += m_TurnController.Turn;
            }
        }
        
    }

    private void OnDestroy()
    {
        if (m_Destructible != null)
        {
            m_Destructible.DeathEvent -= Death;
        }
        if (m_PlayerSoundController != null)
        {
            if (m_Destructible != null)
            {
                m_Destructible.ApplyDamageEvent -= m_PlayerSoundController.DamageSound;
            }
            if (m_JumpController != null)
            {
                m_JumpController.JumpEvent -= m_PlayerSoundController.JumpSound;
            }
            if (m_ProjectileSpawner != null)
            {
                m_ProjectileSpawner.SpawnProjectileEvent -= m_PlayerSoundController.ShotSound;
            }
            if (m_CoinCollector != null)
            {
                m_CoinCollector.PickUpEvent -= m_PlayerSoundController.PickUpSound;
            }
        }
        if ( m_InputController != null)
        {
            if (m_MovementController != null)
            {
                m_InputController.DirectionUpdateEvent -= m_MovementController.SetDirection;
            }
            if (m_JumpController != null)
            {
                m_InputController.SpacePressedEvent -= m_JumpController.TryJump;
            }
            if (m_ProjectileSpawner != null)
            {
                m_InputController.MousePressedEvent -= m_ProjectileSpawner.SpawnProjectile;
            }
            if (m_TurnController != null)
            {
                m_InputController.DirectionUpdateEvent -= m_TurnController.Turn;
            }
        }
        
    }
    
    private void Death()
    {
        gameObject.SetActive(false);
    }
}
