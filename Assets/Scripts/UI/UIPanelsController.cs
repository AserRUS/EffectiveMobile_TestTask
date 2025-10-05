using UnityEngine;

public class UIPanelsController : MonoBehaviour
{
    [SerializeField] private GameObject m_GameOverPanel;
    [SerializeField] private GameObject m_FinishPanel;
    [SerializeField] private GameObject m_PausePanel;
    public void ActivateGameOverPanel()
    {
        m_GameOverPanel.SetActive(true);
    }
    public void ActivateFinishPanel()
    {
        m_FinishPanel.SetActive(true);
    }
    public void ActivatePausePanel()
    {
        m_PausePanel.SetActive(true);
    }
    public void DeactivatePausePanel()
    {
        m_PausePanel.SetActive(false);
    }
}

