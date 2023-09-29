using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleController : MonoBehaviour
{
    public int CastleHealth = 100;
    public int EnemiesIn = 0;

    WavesController wave;

    private void Start()
    {
        wave = GameObject.FindGameObjectWithTag("manager").GetComponent<WavesController>();
        wave.EnimiesBreached = 0;
}
    void Update()
    {
        if(CastleHealth == 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            wave.EnimiesBreached += 1;
            EnemiesIn += 1;
            CastleHealth -= 10;
        }
    }
}
