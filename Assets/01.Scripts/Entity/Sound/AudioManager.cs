using System;
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

    private void Start()
    {
        PlayBGM("BGM");
    }

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
                // SFXPlayer���� ��� ������ ���� Audio Source�� �߰��ߴٸ� 
                if (player.isPlaying) continue;
                player.clip = t.clip;
                player.Play();
                return;
            }
            return;
        }

    }
}
