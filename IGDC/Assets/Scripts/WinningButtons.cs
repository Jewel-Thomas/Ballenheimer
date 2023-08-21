using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningButtons : MonoBehaviour
{
    public GameObject cont,pl,quit;
    
    // Start is called before the first frame update
    void Start()
    {
        cont.gameObject.SetActive(false);
        pl.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Shockwave.arebuttonsactive && Shockwave.exploded)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }


}
