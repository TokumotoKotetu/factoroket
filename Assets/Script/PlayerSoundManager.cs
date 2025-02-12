using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public static PlayerSoundManager instance;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _craftSound;
    [SerializeField] AudioClip _mineoreSound;
    [SerializeField] AudioClip _rocketLaunchSound;
    [SerializeField] AudioClip _missCraftSound;
    [SerializeField] AudioClip _pressButtonSound;

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

    public void PlayCraftSound()
    {
        _audioSource.PlayOneShot(_craftSound);
    }

    public void PlayOreMineSound()
    {
        _audioSource.PlayOneShot(_mineoreSound);
    }

    public void PlayRocketLaunchSound()
    {
        _audioSource.PlayOneShot(_rocketLaunchSound, 0.5f);
    }

    public void PlayMissCraftSound()
    {
        _audioSource.PlayOneShot(_missCraftSound);
    }

    public void PlayPressButtonSound()
    {
        _audioSource.PlayOneShot(_pressButtonSound);
    }
}
