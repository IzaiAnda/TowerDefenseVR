using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform target;
    // Update is called once per frame

    private void Start()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z)); //pongo la y propia para que no cambie su altura
    }

    void Update()
    {

        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WayPoint")
        {
            WayPoint wp = other.gameObject.GetComponent<WayPoint>();
            int random = Random.Range(0, wp.nextPoint.Length);
            target = wp.nextPoint[random];
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));  
        }
    }

    public void setTarget(Transform Target)
    {
        target = Target;
    }

}
