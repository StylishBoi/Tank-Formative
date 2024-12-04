using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----------Audio Source---------------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public AudioClip background;
    public AudioClip hit;
    public AudioClip gameover;
    public AudioClip win;
    public AudioClip shoot;
    public AudioClip death;
    void Start()
    {
        //Starts the game by playing the BGM
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void StopBGM()
    {
        musicSource.Stop();
    }
}
