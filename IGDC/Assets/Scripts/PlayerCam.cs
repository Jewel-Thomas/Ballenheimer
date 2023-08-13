using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Range(100,1000)] [SerializeField] float sensitivity = 250;
    float xRot;
    float yRot;
    public Transform orientation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        // Rotate the mouse and the player

        float mouseX = Input.GetAxisRaw("Mouse X")*sensitivity*Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y")*sensitivity*Time.deltaTime;
#if UNITY_EDITOR
        yRot+=mouseX;
        xRot-=mouseY;
        xRot = Mathf.Clamp(xRot,-60,60);
        transform.rotation = Quaternion.Euler(xRot,yRot,0);
        orientation.rotation = Quaternion.Euler(0,yRot,0);
#else
        if(Input.mousePosition.x > Screen.width/2)
        {
            yRot+=mouseX;
            xRot-=mouseY;
            xRot = Mathf.Clamp(xRot,-60,60);
        }      
        transform.rotation = Quaternion.Euler(xRot,yRot,0);
        orientation.rotation = Quaternion.Euler(0,yRot,0);
#endif
    }
}
