using UnityEngine;

public class AudioService : MonoBehaviour, IAudioService
{
    [SerializeField] private AudioSource _audioSource;
    
    public void PlayAudio(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
}