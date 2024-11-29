using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;

    private float Cooldown;
    private Coroutine shootRoutine;
    
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }  

    void Update()
    {
        Cooldown += Time.deltaTime;
    }
    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);;
            
            yield return new WaitForSeconds(fireRate);
        }
    }

    void OnShoot(InputValue value)
    {
        if (value.isPressed && Cooldown>fireRate)
        {
            if(shootRoutine!=null)
            {
                
                StopCoroutine(shootRoutine);
            }
            shootRoutine=StartCoroutine("Fire");
            audioManager.PlaySFX(audioManager.shoot);
            Cooldown=0;
        }
        else
        {
            StopCoroutine("Fire");
            shootRoutine = null;
        }
    }
}
