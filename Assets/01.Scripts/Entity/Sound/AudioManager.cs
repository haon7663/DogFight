using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private Sound[] sfx = null;
    [SerializeField] private Sound[] bgm = null;

    [SerializeField] private AudioSource bgmPlayer = null;
    [SerializeField] private AudioSource[] sfxPlayer = null;

    public void PlayBGM(string bgmName)
    {
        foreach (var t in bgm)
        {
            if (bgmName != t.name) continue;
            bgmPlayer.clip = t.clip;
            bgmPlayer.Play();
        }
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    public void PlaySFX(string sfxName)
    {
        foreach (var t in sfx)
        {
            if (sfxName != t.name) continue;
            
            foreach (var player in sfxPlayer)
            {
                // SFXPlayer에서 재생 중이지 않은 Audio Source를 발견했다면 
                if (player.isPlaying) continue;
                player.clip = t.clip;
                player.Play();
                return;
            }
            Debug.Log("모든 오디오 플레이어가 재생중입니다.");
            return;
        }
        Debug.Log(sfxName + " 이름의 효과음이 없습니다.");
    }
}
