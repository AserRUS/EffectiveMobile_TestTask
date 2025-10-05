using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Destructible m_Player;
    [SerializeField] private UIPanelsController m_UIPanelsController;
    [SerializeField] private InputController m_InputController;
    [SerializeField] private Finish m_Finish;
    [SerializeField] private Pauser m_Pauser;
    private void Start()
    {
        if (m_Player != null)
        {
            m_Player.DeathEvent += GameOver;
        }
        if (m_Finish != null)
        {
            m_Finish.FinishEvent += Finish;
        }
    }
    private void OnDestroy()
    {
        if (m_Player != null)
        {
            m_Player.DeathEvent -= GameOver;
        }
    }
    private void GameOver()
    {
        if (m_Pauser != null)
        {
            m_Pauser.DisablePauser();
        }
        if (m_UIPanelsController != null)
        {
            m_UIPanelsController.ActivateGameOverPanel();
        }
        if (m_InputController != null)
        {
            m_InputController.DisableInputController();
        }
        
    }
    private void Finish()
    {
        if (m_Pauser != null)
        {
            m_Pauser.DisablePauser();
        }
        if (m_UIPanelsController != null)
        {
            m_UIPanelsController.ActivateFinishPanel();
        }
        if (m_InputController != null)
        {
            m_InputController.DisableInputController();
        }
    }
}
