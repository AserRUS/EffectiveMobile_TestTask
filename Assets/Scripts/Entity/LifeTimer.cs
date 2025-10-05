using System.Collections;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private float m_LifeTime;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(m_LifeTime);
        Destroy(gameObject);
    }
}
