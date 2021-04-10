using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int maxWaves = 3;

    public bool inWave;

    public Transform enemyPrefav;

    public Transform moverTarget;

    public float timeWaves = 5f;

    private float countDown = 5f;
    private int waveNumbers = 0;

    public List<List<int[]>> waves;

    // Start is called before the first frame update
    void Start()
    {
        inWave = false;
        waves = new List<List<int[]>>();
        List<int[]> waveOne = new List<int[]>();
        waveOne.Add(new int[] { 0, 2 });
        List<int[]> waveTwo = new List<int[]>();
        waveTwo.Add(new int[] { 0, 0 });
        waveTwo.Add(new int[] { 0, 0 });
        List<int[]> waveThree = new List<int[]>();
        waveThree.Add(new int[] { 0, 2 });
        waves.Add(waveOne);
        waves.Add(waveTwo);
        waves.Add(waveThree);
    }

    public void startWave(int waveNumber) {
        inWave = true;
        StartCoroutine(Spawn(waveNumber));
    }

    /* Update is called once per frame
    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(Spawn());
            countDown = timeWaves * waveNumbers;
        }
        countDown -= Time.deltaTime;
    }
    */

    IEnumerator Spawn(int waveNumber)
    {

        List<int[]> thisWave = waves[waveNumber];

        foreach (int[] enemy in thisWave)
        {
            for (int i = 0; i < enemy[1]; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f);
            }
        }
        inWave = false;
        /*
        waveNumbers++;

        for (int i = 0; i < waveNumbers; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        */
    }

    private void SpawnEnemy()
    {
        Transform go = Instantiate(enemyPrefav, transform.position, transform.rotation);

        go.GetComponent<Mover>().setTarget(moverTarget);
    }

}
