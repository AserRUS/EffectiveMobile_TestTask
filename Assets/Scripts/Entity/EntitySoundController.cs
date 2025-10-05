using UnityEngine;

public class EntitySoundController : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_JumpSound;
    [SerializeField] private AudioClip m_PickUpSound;
    [SerializeField] private AudioClip m_ShotSound;
    [SerializeField] private AudioClip m_DamageSound;

    public void JumpSound()
    {
        if (m_AudioSource != null)
        {
            m_AudioSource.PlayOneShot(m_JumpSound);
        }        
    }
    public void PickUpSound()
    {
        if (m_AudioSource != null)
        {
            m_AudioSource.PlayOneShot(m_PickUpSound);
        }        
    }
    public void ShotSound()
    {
        if (m_AudioSource != null)
        {
            m_AudioSource.PlayOneShot(m_ShotSound);
        }       
    }
    public void DamageSound()
    {
        if (m_AudioSource != null)
        {
            m_AudioSource.PlayOneShot(m_DamageSound);
        }        
    }
}
