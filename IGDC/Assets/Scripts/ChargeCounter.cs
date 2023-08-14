using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChargeCounter : MonoBehaviour
{
    public int ChargeValue = 0;
    public int DelayAmount = 1; // Second count
	public TMP_Text ChargeCounterText;
    protected float Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

		if (Timer >= DelayAmount)
		{
			Timer = 0f;
			ChargeValue++; // For every DelayAmount or "second" it will add one 
			ChargeCounterText.text = "Motar charge: " + ChargeValue;
		}
        
    }
}
