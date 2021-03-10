using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Transform enemyPrefav;

    public Transform spawner;

    public Transform moverTarget;

    public float timeWaves = 5f;
    private float countDown = 5f;

    private int waveNumbers = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown <= 0f)
        {
            StartCoroutine(Spawn());
            countDown = timeWaves*waveNumbers;
        }
        countDown -= Time.deltaTime;
    }

    IEnumerator Spawn()
    {
        waveNumbers++;

        for (int i = 0; i < waveNumbers; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }

    }

    private void SpawnEnemy()
    {
       Transform go = Instantiate(enemyPrefav, spawner.position, spawner.rotation);

        go.GetComponent<Mover>().setTarget(moverTarget);
    }
}
