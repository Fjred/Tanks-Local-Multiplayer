using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Vector2 damageLimits = new Vector2(10, 20);
    public GameObject explosionVfx;
    private Rigidbody rb;

    
    public float lifetime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 1000f);
        Invoke(nameof(Explode), lifetime);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tank") || other.gameObject.CompareTag("Destructable"))
        {
            var health = other.gameObject.GetComponent<Health>();
           

            if (health != null)
            {
                var damage = Random.Range(damageLimits.x, damageLimits.y);
                print(damage);
                health.TakeDamage(damage);
            }
                
        
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(explosionVfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
