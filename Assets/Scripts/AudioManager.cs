using System;
using TMPro.EditorUtilities;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----------Audio Source---------------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    public AudioClip background;
    public AudioClip hit;
    public AudioClip gameover;
    public AudioClip win;
    public AudioClip shoot;
    public AudioClip death;
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void StopBGM()
    {
        musicSource.Stop();
    }
}
