using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private int startHp = 5;

    private int _hp;
    
    AudioManager audioManager;
    Enemies enemies;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        enemies = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemies>();
    }    
    void Start()
    {
        _hp=startHp;
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        audioManager.PlaySFX(audioManager.hit);
        if (_hp <= 0)
        {
            enemies.Death();
            audioManager.PlaySFX(audioManager.death);
            Destroy(gameObject);
        }
        
    }
    
}
