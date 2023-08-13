using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI fpsText; 
    [SerializeField] TextMeshProUGUI healthText;
    float deltaTime = 0.0f;
    Color tempColor;
    [SerializeField] AudioSource bgm;
    bool isPaused = false;
    [SerializeField] GameObject pausedPanel;
    [SerializeField] GameObject otherUI;
    public static float redHealth;
    public static float blueHealth;
    // [SerializeField] TextMeshProUGUI redHealthText;
    // [SerializeField] TextMeshProUGUI blueHealthText;
    public static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        redHealth = 1100;
        blueHealth = 1600;
        tempColor.b = 0;
        tempColor.a = 1;
        audioSource = bgm;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateFPS();
        ChangeHealthText();
        if(!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            isPaused = !isPaused;
        }
        else if(isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
            isPaused = !isPaused;
        }
    }

    void CalculateFPS()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
        fpsText.text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
    }

    void Pause()
    {
        Time.timeScale = 0;
        bgm.Pause();
        pausedPanel.SetActive(true);
        otherUI.SetActive(false);
    }
    void Resume()
    {
        Time.timeScale = 1;
        bgm.Play();
        pausedPanel.SetActive(false);
        otherUI.SetActive(true);
    }

    public void ChangeHealthText()
    {
        float currentHealth = player.GetHealth();
        healthText.text = $"Health : {currentHealth}";
    }

    public void ChangeColor()
    {
        float currentHealth = player.GetHealth();
        tempColor.r = (100-currentHealth)/100;    // Increases the red color as the health goes down
        tempColor.g = currentHealth/100;          // Decreases the green color as the health goes down
        healthText.color = tempColor;
    }
}
