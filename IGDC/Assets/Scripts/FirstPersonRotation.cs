using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonRotation : MonoBehaviour
{
    [Range(0.1f,1)] [SerializeField] float sensitivity = 0.5f;
    Vector2 turn;
    Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        QualitySettings.pixelLightCount = 10;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
        MouseRotation();
        #endif
        TouchRotation();
    }

    void MouseRotation()
    {
        turn.x += Input.GetAxis("Mouse X")*sensitivity;
        turn.y = Mathf.Clamp(turn.y + Input.GetAxis("Mouse Y")*sensitivity,-35,35);
        transform.localRotation = Quaternion.Euler(-turn.y,turn.x,0);
    }

    void TouchRotation()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                turn.x += touch.deltaPosition.x*sensitivity*0.3f;
                turn.y = Mathf.Clamp(turn.y+touch.deltaPosition.y*sensitivity*0.3f,-35,35);
                transform.localRotation = Quaternion.Euler(-turn.y,turn.x,0);
            }
        }
    }


}
