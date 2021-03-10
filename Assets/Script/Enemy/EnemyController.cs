using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform damagePoint;

    public int life;

    public HealthBar healthBar;

    void Start()
    {
        healthBar.setMaxHealth(life);
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
        healthBar.setHealth(life);
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "House":
                collision.collider.transform.root.gameObject.GetComponent<House>().life -= 1;
                Destroy(this.gameObject);
                break;
        }
        
    }
}
