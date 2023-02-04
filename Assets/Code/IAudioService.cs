using UnityEngine;

public interface IAudioService:IService
{
    void PlayAudio(AudioClip audioClip);
}