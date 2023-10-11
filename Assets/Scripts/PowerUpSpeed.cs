using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    public float speedIncrease = 1.2f;
    public float time = 10;

    private Player player;
    private float oldSpeed;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tank"))
        {
            //tp out of view
            transform.position = new Vector3(0, 100, 0);
            
            player = other.gameObject.GetComponent<Player>();
            oldSpeed = player.moveSpeed;

            StartCoroutine(ChangeSpeed());

            StartCoroutine(ResetPositionAfterDelay(time));
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
    IEnumerator ChangeSpeed()
    {
        player.moveSpeed *= speedIncrease;
        yield return new WaitForSeconds(time);
        player.moveSpeed = oldSpeed;
    }
}
