using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float cooldown = 1f;
    public float lastShot = 0f;

    public float moveSpeed = 5f;
    public float rotateSpeed = 3f;
    
    public float bodyRotationSpeed = 3f;

    private Vector2 movementInput;
    private Vector2 rotationInput;

    public AudioClip shootSound;

    public AudioSource audioSource;

    public Transform turret;
    public Transform body;
    
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    public Image crown;

    void Update()
    {
        // Move
        var input = new Vector3(movementInput.x, 0, movementInput.y);
        var direction = (input.x * turret.right + input.z * turret.forward);
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Rotate body
        if(direction != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(direction);
            body.rotation = Quaternion.Slerp(body.rotation, targetRotation, bodyRotationSpeed * Time.deltaTime);

        }

        // Rotate turret
        float rotation = rotationInput.x * rotateSpeed * Time.deltaTime;
        turret.Rotate(Vector3.up, rotation);
    }

    private void Start()
    {
        var x = Random.Range(-120, 120);
        var z = Random.Range(-120, 120);

        var playerInput = GetComponent<PlayerInput>();
        var renderer = turret.gameObject.GetComponent<Renderer>();
        transform.position = new Vector3(x, 0, z);

        // Check which player this is
        if (GameManager.instance.playerCount == 1)
            renderer.material.color = GameManager.instance.player1;
        else
            renderer.material.color = GameManager.instance.player2;
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        movementInput = value.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext value)
    {
        rotationInput = value.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext value)
    {
        if(Time.time > lastShot + cooldown)
        {
            audioSource.PlayOneShot(shootSound, 0.1f);
            Instantiate(bulletPrefab, shootingPoint.position, turret.rotation);
            lastShot = Time.time;
        }

    }
}
