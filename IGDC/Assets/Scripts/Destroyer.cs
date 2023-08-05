using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public SpawnPlayers spawnPlayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // if(other.CompareTag("Player"))
        // {
        //     spawnPlayers.RandomPosition();
        // }
        // else if(other.CompareTag("AI"))
        // {
        //     spawnPlayers.RandomPosition();
        // }
        // else
        // {
        //     Destroy(other.gameObject);
        // }
    }
}
