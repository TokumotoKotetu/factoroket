using UnityEngine;
using Cinemachine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker instance;
    CinemachineBasicMultiChannelPerlin _perlin;

    float _shakeDuration = 0f;
    float _shakeAmplitude = 0f;
    float _shakeFrequency = 0f;

    private void Awake()
    {
        instance = this;
        _perlin = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if(_shakeDuration > 0)
        {
            _shakeDuration -= Time.deltaTime;

            if( _shakeDuration <= 0 ) 
            {
                StopShake();
            }
        }
    }

    public void ShakeCamera(float amplitude, float frequency, float duration)
    {
        _shakeAmplitude = amplitude;
        _shakeFrequency = frequency;
        _shakeDuration = duration;

        _perlin.m_AmplitudeGain = amplitude;//U“®‚Ì‹­‚³
        _perlin.m_FrequencyGain = frequency;//U“®‚Ì‘¬‚³
    }

    public void StopShake()
    {
        _perlin.m_AmplitudeGain = 0f;
        _perlin.m_FrequencyGain = 0f;
    }
}
