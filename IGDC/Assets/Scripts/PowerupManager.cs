using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] PowerUps;
    public Transform[] SpawnLocations;
    bool powerspawn;
    // Start is called before the first frame update
    void Start()
    {
        powerspawn=false;        
    }

    // Update is called once per frame
    void Update()
    {
        if(powerspawn=true)
        {
           // StartCoroutine(PowerCoolDown());
        }
        
    }
}
