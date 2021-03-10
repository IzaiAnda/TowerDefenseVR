using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{

    TowerController father;

    float timeToShot;

    Transform target;

    private void Start()
    {
        father = transform.parent.gameObject.GetComponent<TowerController>();
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Enemy":
                target = other.GetComponent<EnemyController>().damagePoint;
                father.towerHead.transform.LookAt(target);
                if (Time.time > timeToShot)
                {
                    Instantiate(father.bullet, father.bulletSpawnPoint.position, father.bulletSpawnPoint.rotation);
                    timeToShot = Time.time + father.rateOfFire;
                }
                break;
        }
    }
}
