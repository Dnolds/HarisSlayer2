using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    int currentIDCount = 0;
    public static RoundManager roundManager;
    public int difficulty = 2;
    int round = 0;
    public float score;
    public Vector3[] spawnpoints;
    public GameObject haris;
    public Text mainText;
    public Text aliveText;
    public Text scoreText;
    bool merged = false;
    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("Spawnpoint").Select(e => e.transform.position).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        if (!CheckIfEnemiesAlive())
        {
            round++;
            SpawnEnemies();
        }
    }
    bool CheckIfEnemiesAlive()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            return false;
        }
        return true;
    }
    void SpawnEnemies()
    {
        int j = 0;
        for(int i = 0; i < round * 5 * difficulty; i++,j++)
        {
            if (j >= spawnpoints.Length)
            {
                j = 0;
            }
           GameObject Haris = Instantiate(haris, new Vector2(spawnpoints[j].x+Random.Range(-1.5f,1.5f),spawnpoints[j].y+Random.Range(-1.5f,1.5f)), Quaternion.identity);
            Haris.GetComponent<Enemy>().id = currentIDCount;
            currentIDCount++;


        }
    }
    public void UpdateScore()
    {
        mainText.text = $"Round: {round}";
        aliveText.text = $"Alive: {GameObject.FindGameObjectsWithTag("Enemy").Length}";
        scoreText.text = score+"";
    }
    void Awake()
    {
        if (roundManager != null)
            GameObject.Destroy(roundManager);
        else
            roundManager = this;

        DontDestroyOnLoad(this);
    }
    public int highestId()
    {
        int highest = 0;
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            int currentID = e.GetComponent<Enemy>().id;
            if (currentID > highest)
            {
                highest = currentID;
            }
        }
        return highest;
    }

}
