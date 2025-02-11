using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public static PlayerSoundManager instance;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _getItemSound;
    [SerializeField] AudioClip _mineoreSound;
    [SerializeField] AudioClip _rocketLaunchSound;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayGetItemSound()
    {
        _audioSource.PlayOneShot(_getItemSound);
    }

    public void PlayOreMineSound()
    {
        _audioSource.PlayOneShot(_mineoreSound);
    }

    public void PlayRocketLaunchSound()
    {
        _audioSource.PlayOneShot(_rocketLaunchSound, 0.5f);
    }
}
