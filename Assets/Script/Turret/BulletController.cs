using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "ImpactArea":
                collision.collider.transform.root.gameObject.GetComponent<EnemyController>().life -= 5;
            break;
        }
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Wall":
                Destroy(this.gameObject);
                break;
        }
        
    }
}
