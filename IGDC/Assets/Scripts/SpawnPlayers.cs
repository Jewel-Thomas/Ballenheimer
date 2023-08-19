using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPref;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float yPos = 1.803f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RandomPosition()
    {
        Vector3 randomPos = new Vector3(Random.Range(minX,maxX),yPos,Random.Range(minZ,maxZ));
        playerPref.transform.position = randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
