using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class UIModifier : MonoBehaviour
{
    [SerializeField] float totFillTime;
    [SerializeField] Image fillImage;
    bool filling;
    bool empting;
    private float fill;
    // Start is called before the first frame update
    void Start()
    {
        filling = false;
        empting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(filling)
        {
            FillIt();
        }
        if(empting)
        {
            EmptyIt();
        }
    }

    public void FillBool()
    {
        filling = true;
        empting = false;
    }
    public void EmptyBool()
    {
        empting = true;
        filling = false;
    }

    public void FillIt()
    {
        fill+=Time.deltaTime;
        Mathf.Clamp(fill,0,totFillTime);
        fillImage.fillAmount = fill/totFillTime;
    }
    public void EmptyIt()
    {
        fill-=Time.deltaTime;
        Mathf.Clamp(fill,0,totFillTime);
        fillImage.fillAmount = fill/totFillTime;
    }
}
