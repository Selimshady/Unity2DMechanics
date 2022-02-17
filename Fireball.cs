using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject impactEffect;
    public float coolDown = 2f;

    private GameObject tmpImpact;
    private Rigidbody2D rb;

    // Start is called before the first frame update

    private void OnEnable() 
    {
        if(rb != null) 
        {
            rb.velocity = transform.right * projectileSpeed;
        }
        Invoke("Disable",coolDown);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<PlayerHealth>().shot();
        tmpImpact = Instantiate(impactEffect,transform.position,transform.rotation);
        Disable();
        Destroy(tmpImpact,1.5f);
    }

    private void Disable() 
    {
        gameObject.SetActive(false);
    }
    
    private void OnDisable() 
    {
        CancelInvoke();
    }
}
