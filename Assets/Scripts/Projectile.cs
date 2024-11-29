using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float bulletForce = 50f;  
    void Start()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletForce;
        Destroy(gameObject,2);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Enter ???? : " + other.gameObject.name);

        if (other.gameObject.TryGetComponent(out Destructible objective))
        {
            Destroy(gameObject);
            objective.TakeDamage(1);
        }
    }
    void Update()
    {
        
    }
}
