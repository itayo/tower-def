using System.Collections; 
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform Enemy1;
    public Transform SpawnPoint;
    public float TimeBetweenWaves=10.0f;
    public float countDown=1.0f;
    public Text ui_Countdown;
    private int waveId=0;
    private void Update()
    {
        if(countDown <= 0.0f)
        {
            StartCoroutine(spawnWave());
            countDown = TimeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        if (countDown >= 0)
        {
            ui_Countdown.text = Mathf.Floor(1.0f + countDown).ToString();
        } else ui_Countdown.text ="0";

    }
    IEnumerator spawnWave()
    {
        waveId++;
        
        int enemiesToSpawn =  1;
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }
    }
    private void spawnEnemy()
    {
        Instantiate(Enemy1,SpawnPoint.position,SpawnPoint.rotation);
    }
}
