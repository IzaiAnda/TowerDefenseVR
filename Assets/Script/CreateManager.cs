using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    public Transform tile;
    GameObject floor;

    public List<GameObject> goList;

    void Start()
    {
        floor = new GameObject();
        floor.name = "floor";

        for (int i = 0; i <= 10; i++)
        {
            for (int j = 0; j <= 10; j++)
            {
                Transform go = Instantiate(tile, new Vector3(i, 0, j), transform.rotation);

                go.transform.position = new Vector3(i, 0, j);
                go.transform.parent = floor.transform;
                go.name = i + "-" + j;
            }
        }
    }

    public void StreetLoader(GameObject street)
    {
        goList = new List<GameObject>();
        for (int i = 0; i <= 10; i++)
        {
            for (int j = 0; j <= 10; j++)
            {
                GameObject go = GameObject.Find("/street/"+ i + "-" + j);
                if (go != null)
                {
                    goList.Add(go);
                }
            }
        }
        goList.Sort(SortByName);
    }

    static int SortByName(GameObject p1, GameObject p2)
    {
        return p1.name.CompareTo(p2.name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
