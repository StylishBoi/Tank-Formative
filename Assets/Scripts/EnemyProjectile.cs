using System;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float bulletForce = 50f;
    
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }  
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletForce;
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Enter ???? : " + other.gameObject.name);
        if (other.gameObject.TryGetComponent(out TankControls objective))
        {
            objective.TakeDamage(1);
            Destroy(this.gameObject);
            audioManager.StopBGM();
            audioManager.PlaySFX(audioManager.gameover);
        }
    }
    void Update()
    {
        
    }
}
