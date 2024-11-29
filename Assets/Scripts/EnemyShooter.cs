using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;

    private Coroutine shootRoutine;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnShoot();
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);;
            
            yield return new WaitForSeconds(fireRate);
        }
    }

    void OnShoot()
    {
        shootRoutine=StartCoroutine("Fire");
    }
}
