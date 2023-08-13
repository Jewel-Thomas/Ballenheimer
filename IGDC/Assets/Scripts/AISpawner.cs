using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<GameObject> enemyAI;
    public float minZ;
    public float maxZ;
    public float minX;
    public float maxX;
    public float yPos;
    [Range(1,30)] [SerializeField] float spawmtime;
    private float timer;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        timer = spawmtime;
        num=1;
        GameObject[] temp = GameObject.FindGameObjectsWithTag("AI");
        foreach (var item in temp)
        {
            enemyAI.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        timer = Mathf.Clamp(timer,0,30);
        RemoveAINotActive();
        if(timer <= 0 && enemyAI.Count < 16)
        {
            SpawnEnemy();
            timer = spawmtime;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(minX,maxX),yPos,Random.Range(minZ,maxZ));
        GameObject AI = Instantiate(enemyPrefab,spawnLocation,Quaternion.identity) as GameObject;
        AI.name = $"AI{num}";
        num++;
        AI.transform.rotation = Quaternion.Euler(AI.transform.rotation.x,AI.transform.rotation.y-180,AI.transform.rotation.z);
        enemyAI.Add(AI);
    }

    // Detects the AI Gameobjects that are not active in the scene and removes it from the list
    void RemoveAINotActive()
    {
        foreach (var enemy in enemyAI)
        {
            if(!enemy.activeInHierarchy)
            {
                enemyAI.Remove(enemy);
            }
        }
    }
}
