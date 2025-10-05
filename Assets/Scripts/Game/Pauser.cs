using UnityEngine;


public class Pauser : MonoBehaviour
{        
    [SerializeField] private UIPanelsController m_UIPanelsController;
    [SerializeField] private InputController m_InputController;    
    
    private bool isPause;
    private bool isDisable;
    public void Pause()
    {
        if (isPause == true)
        { 
            return;
        }

        m_InputController.DisableInputController();
        Time.timeScale = 0;
        m_UIPanelsController.ActivatePausePanel();

        isPause = true;        
    }
    public void UnPause()
    {
        if (isPause == false) 
        {
            return;
        }        
                
        m_InputController.EnableInputController();
        Time.timeScale = 1;
        m_UIPanelsController.DeactivatePausePanel();

        isPause = false;
    }

    private void Update()
    {
        CheckingKeystrokes();
    }

    public void ChangePauseState()
    {
        if (isPause == true)
        {            
            UnPause();
        }            
        else
        {            
            Pause();
        }            
    }
    private void CheckingKeystrokes() 
    {
        if (isDisable == true)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseState();
        }
    }

    public void DisablePauser()
    {
        isDisable = true;
    }
    public void EnablePauser()
    {
        isDisable = false;
    }
}
