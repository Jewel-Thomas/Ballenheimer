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
    public bool isover = false;
    [SerializeField] GameObject pausedPanel, gameoverPan;
    [SerializeField] GameObject otherUI;
    public static float redHealth;
    public static float blueHealth;
    // [SerializeField] TextMeshProUGUI redHealthText;
    // [SerializeField] TextMeshProUGUI blueHealthText;
    public static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
        if(!isPaused && Input.GetKeyDown(KeyCode.Escape) && !isover)
        {
            Pause();
            isPaused = !isPaused;
        }
        else if(isPaused && Input.GetKeyDown(KeyCode.Escape) && !isover)
        {
            Resume();
            isPaused = !isPaused;
        }
        //Time.timeScale += (1f/4f)*Time.unscaledDeltaTime;
        //Time.timeScale = Mathf.Clamp(Time.timeScale,0f,1f);
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        bgm.Pause();
        pausedPanel.SetActive(true);
        otherUI.SetActive(false);
    }
    void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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

    public void GameOver()
    {
        //UIManager.audioSource.PlayOneShot(other.gameObject.GetComponent<Player>().playerAudio);
        //parentObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        otherUI.SetActive(false);
        Destroy(pausedPanel);
        isover = true;
        player.enabled = false;
        StartCoroutine(ScaleTime(1.0f, 0.0f, 3.0f));
    }
    IEnumerator ScaleTime(float start, float end, float time) 
    {
	    float lastTime = Time.realtimeSinceStartup;
	    float timer = 0.0f;
        //Time.fixedDeltaTime = Time.timeScale * 0.02f;
	    while (timer < time) 
        {
		    Time.timeScale = Mathf.Lerp (start, end, timer / time);
		    timer += (Time.realtimeSinceStartup - lastTime);
		    lastTime = Time.realtimeSinceStartup;
            Time.fixedDeltaTime = Time.timeScale;
		    yield return null;
	    }
	
	    Time.timeScale = end;
        gameoverPan.SetActive(true);	
    }
}
