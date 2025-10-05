using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField] private float Power;
    [SerializeField] private LayerMask m_PushedLayers;

    private Vector2 direction;
    private Rigidbody2D targetRigidbody;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        targetRigidbody = collision.transform.GetComponent<Rigidbody2D>();
        if (targetRigidbody != null)
        {
            if ((m_PushedLayers.value & (1<< collision.gameObject.layer)) != 0)
            {
                direction = (Vector2)targetRigidbody.transform.position - collision.contacts[0].point;
                targetRigidbody.AddForce(direction.normalized * Power, ForceMode2D.Impulse);
            }            
        }
    }

    
        
    
}
