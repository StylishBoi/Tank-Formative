using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float bulletForce = 50f;
    
    AudioManager _audioManager;
    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
            objective.PlayerDeath();
            Destroy(this.gameObject);
            _audioManager.StopBGM();
            _audioManager.PlaySfx(_audioManager.gameover);
        }
    }
}
