using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_Target;
    [SerializeField] private float m_CameraSpeedX;
    [SerializeField] private float m_CameraSpeedY;   

    private Vector3 newCamPos;

    private void Start()
    {
        newCamPos.z = transform.position.z;
    }

    private void LateUpdate()
    {
        CameraMovement();
    } 
    
    private void CameraMovement()
    {
        if (m_Target == null)
        {
            return;
        }

        newCamPos.x = Mathf.Lerp(transform.position.x, m_Target.transform.position.x, m_CameraSpeedX * Time.deltaTime);
        newCamPos.y = Mathf.Lerp(transform.position.y, m_Target.transform.position.y, m_CameraSpeedY * Time.deltaTime);
        transform.position = newCamPos;
    }

}
