using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    public bool IsDisable => isDisable;

    public event UnityAction<int> DirectionUpdateEvent;
    public event UnityAction SpacePressedEvent;
    public event UnityAction MousePressedEvent;

    private int direction;
    private bool isDisable;

    private void Update()
    {
        CheckingKeystrokes();
    }
    
    private void CheckingKeystrokes()
    {
        if (isDisable == true)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpacePressedEvent?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            MousePressedEvent?.Invoke();
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
        }
        else
        {
            direction = 0;
        }

        DirectionUpdateEvent?.Invoke(direction);
    }

    public void DisableInputController()
    {
        isDisable = true;
        direction = 0;
        DirectionUpdateEvent?.Invoke(direction);
    }
    public void EnableInputController()
    {
        isDisable = false;        
    }
}
