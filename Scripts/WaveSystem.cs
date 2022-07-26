using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Wave
{
    public string WaveName { get; set; }
    public string WaveDesc { get; set; }
    public int NumHaris { get; set; }
    public int WaveIndex { get; set; }
    public bool IsSpecial { get; set; }
    public float BERH { get; set; } //Basic Round Health
    public float BERD { get; set; } //Basic Round Dmg
}
public class WaveSystem : MonoBehaviour
{
    public Text Title;
    public Text Desc;
    public GameObject HarisPrefab;
    public GameObject Spawnpoint1;
    public GameObject Spawnpoint2;
    public GameObject Spawnpoint3;
    public GameObject Spawnpoint4;
    public GameObject Spawnpoint5;
    public GameObject Spawnpoint6;
    public int currentRound = 0;
    List<GameObject> Spawnpoints = new List<GameObject>();
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(WaitBeforeFirstRound());
    }
    void Start()
    {
       
        Spawnpoints.Add(Spawnpoint1);
        Spawnpoints.Add(Spawnpoint2);
        Spawnpoints.Add(Spawnpoint3);
        Spawnpoints.Add(Spawnpoint4);
        Spawnpoints.Add(Spawnpoint5);
        Spawnpoints.Add(Spawnpoint6);
       


    }

    // Update is called once per frame
    void Update()
    {
        if (CheckIfEnemiesDead())
        {
            NextRound();
        }
    }



    public bool CheckIfEnemiesDead()
    {
        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        if(enemies.Count <= 0)
        {
            return true;
        }
        return false;
        
    }

    private void NextRound()
    {
        
        var random = new System.Random();
        currentRound++;
        Wave wave = RoundChoose(currentRound);
        StartCoroutine(WaitForNextRound(wave.WaveName, wave.WaveDesc));
        int j = 0;
        for (int i = 0; i < wave.NumHaris-1; i++)
        {
            if(j == 6)
            {
                j = 0;
            }
           GameObject enemy = Instantiate(HarisPrefab, new Vector3(Spawnpoints[j].transform.position.x + random.Next(-2,4),Spawnpoints[j].transform.position.y, Spawnpoints[j].transform.position.z),Spawnpoints[j].transform.rotation);
          Health health = enemy.GetComponent<Health>();
            health.health = (int)wave.BERH;
            health.damage = wave.BERD;

            
            j++;
        }

    }

    public Wave RoundChoose(int num)
    {
        switch (num)
        {
            case 1:
                return new Wave { WaveName = "First Wave", WaveDesc = "Show me what u got!", NumHaris = 4, BERH = 70,BERD = 15, WaveIndex = 1, IsSpecial = false };
            case 2:
                return new Wave { WaveName = "Second Wave", WaveDesc="Not bad Kid!", NumHaris = 9, BERH = 70, BERD = 15, WaveIndex = 2, IsSpecial = false };
            case 3:
                return new Wave { WaveName = "Third Wave", WaveDesc = "It's gonna be a long way", NumHaris = 9, BERH = 70, BERD = 15, WaveIndex = 3, IsSpecial = false };
            case 4:
                return new Wave { WaveName = "4th Wave", WaveDesc = "So u decided to stay?", NumHaris = 15, BERH = 90, BERD = 20, WaveIndex = 4, IsSpecial = false };
            case 5:
                return new Wave { WaveName = "5th Wave", WaveDesc = "Not that easy huh?", NumHaris = 9, BERH = 120, BERD = 25, WaveIndex = 5, IsSpecial = false };
            case 6:
                return new Wave { WaveName = "6th Wave", WaveDesc = "Now you could call a cool run :)", NumHaris = 20, BERH = 110, BERD = 20, WaveIndex = 6, IsSpecial = false };
            case 7:
                return new Wave { WaveName = "7th Wave", WaveDesc = "Wanna Give up?", NumHaris = 25, BERH = 110, BERD = 20, WaveIndex = 7, IsSpecial = false };
            case 8:
                return new Wave { WaveName = "Boss Fight", WaveDesc = "HERTHA IS HERE", NumHaris = 30, BERH = 60, BERD = 20, WaveIndex = 8, IsSpecial = true };
        }
        return new Wave { WaveName = "Last Wave",WaveDesc ="Never gonna give u up", NumHaris = 50, WaveIndex = -1,BERH=220,BERD=50, IsSpecial = true };
    }
    IEnumerator WaitForNextRound(string TitleText, string DescText)
    {
        Title.gameObject.SetActive(true);
        Title.text = TitleText;
        Desc.gameObject.SetActive(true);
        Desc.text = DescText;

        yield return new WaitForSeconds(5);
        Title.gameObject.SetActive(false);
        Desc.gameObject.SetActive(false);
    }
    IEnumerator WaitBeforeFirstRound()
    {
        yield return new WaitForSeconds(10);
    }
}
