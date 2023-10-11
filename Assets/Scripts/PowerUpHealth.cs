using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{
    private Health hp;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tank"))
        {
            //tp out of view
            transform.position = new Vector3(0, 100, 0);

            hp = other.gameObject.GetComponent<Health>();
            hp.health = hp.maxHealth;
            hp.healthBar.localScale = new Vector3((float)hp.health / hp.maxHealth, 1, 1);

            StartCoroutine(ResetPositionAfterDelay(5f));
        }
    }

    private IEnumerator ResetPositionAfterDelay(float delay)
    {
        var x = Random.Range(-80, 80);
        var z = Random.Range(-80, 80);
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Move the power-up back to its original position
        transform.position = new Vector3(x, 0.1363333f, z);
    }

}


