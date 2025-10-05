using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int m_Damage;
    [SerializeField] private LayerMask m_DamagedLayers;

    private Destructible destructible;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        destructible = collision.transform.GetComponent<Destructible>();
        if (destructible != null)
        {
            if ((m_DamagedLayers.value & (1 << collision.gameObject.layer)) != 0) 
            {
                destructible.ApplyDamage(m_Damage);
            }                
        }
    }
}
