using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GlobalDataExpoterController : MonoBehaviour
{
    WavesController wave;
    private static int EnimiesKilled;
    private static int EnimiesBreached;
    private static int WaveNumber;

    public TextMeshProUGUI Ekilled;
    public TextMeshProUGUI Ebreached;
    public TextMeshProUGUI Wnumber;

    private void Start()
    {
        wave = GameObject.FindGameObjectWithTag("manager").GetComponent<WavesController>();
    }

    private void Update()
    {
        EnimiesKilled = wave.EnimiesKilled;
        EnimiesBreached = wave.EnimiesBreached;
        WaveNumber = wave.WavenumberTemp;

        Ekilled.text = ("Enimies Killed : " + EnimiesKilled);
        Ebreached.text = ("Enimies Breached : " + EnimiesBreached);
        Wnumber.text = ("Wave Compleated : " + WaveNumber + " Out Of " + wave.Totalwavenumber);
    }

    public void playAgain()
    {
        SceneManager.LoadScene("WithOutParent");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
