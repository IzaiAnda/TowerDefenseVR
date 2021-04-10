using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class levelController : MonoBehaviour
{

    GameObject spawnersGO;

    List<GameObject> spawners;

    int waves;

    bool inWave;

    public GameObject turret;
    public Text coin;
    int coins;
    public Text HP;
    public GameObject house;
    public GameObject finish;
    public int maxMaxWaves = 3;

    public float rayLength = 100;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        finish.SetActive(false);
        coins = 5;
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
                int maxwaves = child.GetComponent<Spawner>().maxWaves;
                if (maxMaxWaves < maxwaves) maxMaxWaves = maxwaves;
            }
            
        }

    }
    public void addGold(int number)
    {
        coins += number;
    }
    // Update is called once per frame
    void Update()
    {

        if (waves >= maxMaxWaves && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finish.SetActive(true);
        }

        coin.text = coins.ToString();
        HP.text = house.GetComponent<House>().life.ToString();

        /*if (Input.GetKeyDown("space"))
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

        if (Input.GetMouseButtonDown(0) && coins >= 5)
        {
            coins -= 5;
            Debug.Log("patata");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Tile":
                        Debug.Log(hit.collider.transform.position);
                        GameObject go = Instantiate(turret, hit.collider.transform.position, hit.collider.transform.rotation);
                        //go.transform.parent = hit.collider.transform.parent;
                        break;
                }
            }
        }*/
    }
}
