using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float score;
    public static ScoreManager Instance;
    // A Singelton Instance created if the instance is not present and is destroyed if present
    void Start()
    {
        if(!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            return;
        }
        Destroy(this);
    }

    public void AddScore(float amount)
    {
        score+=amount;
        scoreText.text = $"Score : {score}";
    }

}
