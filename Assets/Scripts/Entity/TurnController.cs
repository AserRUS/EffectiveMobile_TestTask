using UnityEngine;

public class TurnController : MonoBehaviour
{
    public void Turn(int direction)
    {
        if (direction == -1)
        {
            TurnRight();
        }
        else if (direction == 1)
        {
            TurnLeft();
        }
    }
    private void TurnRight()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void TurnLeft()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
