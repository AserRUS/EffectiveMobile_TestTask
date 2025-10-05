using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileSpawner : MonoBehaviour
{
    public event UnityAction SpawnProjectileEvent;

    [SerializeField] private Projectile m_ProjectilePrafab;
    [SerializeField] private float m_FireRate;

    private bool isReady = true;
    public void SpawnProjectile()
    {
        if (isReady == false || m_ProjectilePrafab == null)
        {
            return;
        }
        Instantiate(m_ProjectilePrafab, transform.position, transform.rotation);
        SpawnProjectileEvent?.Invoke();
        isReady = false;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(m_FireRate);
        isReady = true;
    }
}
