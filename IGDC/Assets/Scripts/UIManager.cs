using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class UIManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI fpsText; 
    [SerializeField] TextMeshProUGUI pingText;
    [SerializeField] TextMeshProUGUI healthText;
    float deltaTime = 0.0f;
    Color tempColor;
    // Start is called before the first frame update
    void Start()
    {
        tempColor.b = 0;
        tempColor.a = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateFPS();
        CalculatePing();
        ChangeHealthText();
    }

    void CalculateFPS()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
        fpsText.text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
    }

    void CalculatePing()
    {
        pingText.text = "Ping : " + PhotonNetwork.GetPing(); 
    }

    public void ChangeHealthText()
    {
        float currentHealth = player.GetHealth();
        healthText.text = $"Health : {currentHealth}";
    }

    public void ChangeColor()
    {
        float currentHealth = player.GetHealth();
        tempColor.r = (100-currentHealth)/100;
        tempColor.g = currentHealth/100;
        healthText.color = tempColor;
    }
}
