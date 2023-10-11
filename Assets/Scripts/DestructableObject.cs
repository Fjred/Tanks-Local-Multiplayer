using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    public GameObject breakVfx;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Instantiate(breakVfx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }   
    }
}
