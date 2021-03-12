using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    public Transform tile;
    public GameObject floor;
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
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
