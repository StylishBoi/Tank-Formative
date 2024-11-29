using UnityEngine;

public class Enemies : MonoBehaviour
{
    private int _total=4;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    } 
    
    public void Death()
    {
        _total -= 1;
        if (_total <= 0)
        {
            audioManager.StopBGM();
            audioManager.PlaySFX(audioManager.win);
            Application.Quit();
        }
    }
}
