using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundService : Singleton<SoundService>
{
    private Dictionary<string, AudioClip> _audioClipDict = null;
    private AudioSource _audioSource = null;

    public override void StartService()
    {
        _audioSource = this.gameObject.AddComponent<AudioSource>();
        
        _audioClipDict = new Dictionary<string, AudioClip>();

        _audioClipDict.Add("IntroBGM", ResourceService.Instance.LoadBGM("IntroBGM"));
        _audioClipDict.Add("LobbyBGM", ResourceService.Instance.LoadBGM("LobbyBGM"));
        _audioClipDict.Add("CombatBGM", ResourceService.Instance.LoadBGM("CombatBGM"));
    }

    public void PlaySound(string audioName)
    {
        _audioSource.Stop();
        _audioSource.clip = _audioClipDict[audioName];
        _audioSource.Play();
    }
}
