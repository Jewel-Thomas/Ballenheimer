using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    Rigidbody rb;
    Vector3 resetPos;
    Vector3 resetRot;
    // Start is called before the first frame update
    void Start()
    {
        resetPos = enemy.transform.position; 
        resetRot = new Vector3(0,180,0.00199556327f);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Reseting the enemy at a random location on a specified area
        if(Input.GetKeyDown(KeyCode.R))
        {
            float xpos = Random.Range(6.5f,12);
            float zpos = Random.Range(18.5f,25);
            Reset(xpos,zpos);
        }
    }

    public void Reset(float xpos, float zpos)
    {
        resetPos.x = xpos;
        resetPos.z = zpos; 
        enemy.transform.position = resetPos;
        rb.velocity = new Vector3(0,0,0);
        rb.angularVelocity = new Vector3(0,0,0);
        enemy.transform.rotation = Quaternion.Euler(resetRot);
    }

}
