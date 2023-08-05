using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOverPosition : MonoBehaviour
{
    [SerializeField] GameObject textMap;
    // Start is called before the first frame update
    void Start()
    {
        PutUpon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PutUpon()
    {
        textMap.transform.position = new Vector3(transform.position.x+1,transform.position.y+2.5f,transform.position.z);
    }
}
