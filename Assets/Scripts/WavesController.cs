using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WavesController : MonoBehaviour
{
    public TextMeshProUGUI wave;

    [SerializeField] private static int currentWave; //current wave
    private int i;
    private int j;
    private int cheakCont;
    private static int enemyxIncrease;
    [SerializeField] int numberOfWaves; //dynamic waveSystem
    [SerializeField] Transform[] EnemySpawn;
    [SerializeField] float timeBetweenEnemySpawns = 0.2f;

    public GameObject[] PlayerRight;
    public GameObject[] PlayerLeft;
    public GameObject[] PlayerUp;
    public GameObject[] PlayerDown;

    public int activeTankNo;
    public int TotalActiveTankNo;
    public turrentShooter turrent;
    public int EnimiesKilled;
    public int EnimiesBreached;
    public int WavenumberTemp;
    public int Totalwavenumber;

    private int TotalHealth = 100;
    private void Start()
    {
        TotalActiveTankNo = 0;
        activeTankNo = turrent.clickedTemp;
        enemyxIncrease = 4;
        currentWave = 1;
        i = 0;
        j = 0;
        cheakCont = 0;
        Totalwavenumber = numberOfWaves;
    }

    private void Update()
    {
        WavenumberTemp = currentWave - 1;

        if (currentWave <= numberOfWaves && Input.GetKey(KeyCode.Space) && cheakCont == 0)
        {
            TotalActiveTankNo += 2;
            wave.text = ("Wave : " + currentWave);
            print(currentWave);
            /*for (int k = 0; k < enemyxIncrease; k++)
            {
                j = 0;
                i = Random.Range(0, 3);
                Instantiate(PlayerRight[i], EnemySpawn[j].position, Quaternion.identity);
                j++;
                i = Random.Range(0, 3);
                Instantiate(PlayerLeft[i], EnemySpawn[j].position, Quaternion.identity);
                j++;
                i = Random.Range(0, 2);
                Instantiate(PlayerUp[i], EnemySpawn[j].position, Quaternion.identity);
                j++;
                i = Random.Range(0, 3);
                Instantiate(PlayerDown[i], EnemySpawn[j].position, Quaternion.identity);
            }*/

            StartCoroutine(SpawnEnemiesWithGap());

            currentWave++;
            enemyxIncrease += 2;
            //StartCoroutine(waitNow());
            cheakCont = 1;
        } // 8 enemies increase per wave
        if(Input.GetKey("q") && cheakCont == 1)
        {
            cheakCont = 0;
        }

        /*if(currentWave < numberOfWaves)
        {
            SceneManager.LoadScene("GameOver");
        }*/
    }

    IEnumerator SpawnEnemiesWithGap()
    {
        for (int k = 0; k < enemyxIncrease; k++)
        {
            j = 0;
            i = Random.Range(0, 3);
            Instantiate(PlayerRight[i], EnemySpawn[j].position, Quaternion.identity);
            j++;
            yield return new WaitForSeconds(timeBetweenEnemySpawns);

            i = Random.Range(0, 3);
            Instantiate(PlayerLeft[i], EnemySpawn[j].position, Quaternion.identity);
            j++;
            yield return new WaitForSeconds(timeBetweenEnemySpawns);

            i = Random.Range(0, 2);
            Instantiate(PlayerUp[i], EnemySpawn[j].position, Quaternion.identity);
            j++;
            yield return new WaitForSeconds(timeBetweenEnemySpawns);

            i = Random.Range(0, 3);
            Instantiate(PlayerDown[i], EnemySpawn[j].position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenEnemySpawns);
        }
    }

    /*IEnumerator waitNow()
    {
        yield return new WaitForSeconds(10);
    }*/
}
