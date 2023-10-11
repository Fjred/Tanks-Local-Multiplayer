using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Color player1;
    public Color player2;

    [HideInInspector]
    public int playerCount = 0;
    public GameObject introCam;

    private PlayerInputManager playerInputManager;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
    public void OnPlayerJoined()
    {
        playerCount++;
    }
    public void DisableIntroCam()
    {
        introCam.SetActive(false);
    }
}
