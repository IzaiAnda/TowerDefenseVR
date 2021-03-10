using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Start is called before the first frame update

    //Visual
    public GameObject towerHead;
    public Transform bulletSpawnPoint;
    public GameObject cannon;
    public GameObject rangeObject;
    //Properties
    public int life;
    public int damage;
    public float range;

    public GameObject bullet;
    public float rateOfFire;

    void Start()
    {
        rangeObject.GetComponent<SphereCollider>().radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
