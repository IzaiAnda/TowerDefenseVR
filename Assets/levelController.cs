using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{

    GameObject spawnersGO;

    List<GameObject> spawners;

    int waves;

    bool inWave;

    // Start is called before the first frame update
    void Start()
    {
        inWave = false;
        waves = 0;
        spawnersGO = GameObject.Find("spawners");
        spawners = new List<GameObject>();
        foreach (Transform child in spawnersGO.transform)
        {
            if (child.gameObject.tag == "Spawner")
            {
                Debug.Log(child.gameObject.name);
                spawners.Add(child.gameObject);
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {

            foreach (GameObject child in spawners)
            {
                if (child.GetComponent<Spawner>().inWave){
                    inWave = true;
                    Debug.Log("Wave ongoing");
                }
            }
            if (!inWave)
            {
                Debug.Log("Starting wave " + (waves + 1));
                foreach (GameObject child in spawners)
                {
                    child.GetComponent<Spawner>().startWave(waves);
                }
                waves++;
            }
            inWave = false;
            
        }
    }
}
