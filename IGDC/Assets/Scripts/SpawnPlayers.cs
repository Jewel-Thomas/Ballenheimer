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
    private float yPos = 1.803f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPos = new Vector3(Random.Range(minX,maxX),yPos,Random.Range(minZ,maxZ));
        PhotonNetwork.Instantiate(playerPref.name,randomPos,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
