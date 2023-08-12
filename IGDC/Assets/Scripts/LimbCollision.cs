using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");
        playerController.isGrounded = true;
        
    }
}
