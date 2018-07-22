using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip ClickSound;
    public AudioClip Destroysound;
    public AudioClip Music;
    private AudioSource audiosource1;
    private AudioSource audiosource2;
    public const string MusicStatus = "Music";
    public const string soundStatus = "sound";
    public void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        audiosource1 = new GameObject("AudioSource1").AddComponent<AudioSource>();
        audiosource2 = new GameObject("AudioSource2").AddComponent<AudioSource>();
        DontDestroyOnLoad(audiosource1);
        DontDestroyOnLoad(audiosource2);
        audiosource2.loop = true;
        if(PlayerPrefs.GetInt(soundStatus,1) == 0)
        {
            audiosource1.mute = true;
        }
        else
        {
            audiosource1.mute = false;
        }
        if (PlayerPrefs.GetInt(MusicStatus,1) == 0)
        {
            audiosource2.mute = true;
        }
        else
        {
            audiosource2.mute = false;
        }
        PlayMusic();
    }
    public void Update()
    {
        
    }
    public void PlayMusic()
    {
        audiosource2.clip = Music;
        audiosource2.Play();
    }
    public void PlaySound(AudioClip clip)
    {
        audiosource1.PlayOneShot(clip);
    }
    public void ToggleSound()
    {
        if(GetSoundMutestatus() == true)
        {
            audiosource1.mute = false;
            PlayerPrefs.SetInt(soundStatus, 0);
        }
        else
        {
            audiosource1.mute = true;
            PlayerPrefs.SetInt(soundStatus, 1);
        }

    }
    public void ToggleMusic()
    {
        if (GetMusicStatus() == true)
        {
            audiosource2.mute = false;
            PlayerPrefs.SetInt(MusicStatus, 0);
        }
        else
        {
            audiosource2.mute = true;
            PlayerPrefs.SetInt(MusicStatus, 1);
        }
    }
    public bool GetSoundMutestatus()
    {
        if (audiosource1.mute)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool GetMusicStatus()
    {
        if (audiosource2.mute)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
