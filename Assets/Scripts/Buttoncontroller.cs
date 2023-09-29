using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buttoncontroller : MonoBehaviour
{
    public bool enableTank;
    public bool disarmTank;

    public TextMeshProUGUI CastleHealth; 
    public TextMeshProUGUI EnemiesBreached;

    CastleController castle;

    private void Start()
    {
        castle = GameObject.FindGameObjectWithTag("base").GetComponent<CastleController>();
    }
    private void Update()
    {
        CastleHealth.text = ("Castle Health : " + castle.CastleHealth);
        EnemiesBreached.text = ("Enimies Breached : " + castle.EnemiesIn);
    }

    public void OnREDButton()
    {
        enableTank = false;
        disarmTank = true;
    }

    public void OnGREENButton()
    {
        disarmTank = false;
        enableTank = true;
    }
}
