using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float rayLength;
    public LayerMask layerMask;
    public GameObject baseTurr;
    public GameObject castle;
    public GameObject wP;
    GameObject selected;
    public GameObject spawn;
    GameObject street;
    bool streetSelected = false;

    private void Awake()
    {
        selected = castle;
        street = new GameObject();
        street.name = "street";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            selected = baseTurr;
            Debug.Log(selected.name);
            streetSelected = false;
        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            selected = castle;
            streetSelected = false;
            Debug.Log(selected.name);
        }
        else if(Input.GetKeyDown(KeyCode.O))
        {
            selected = wP;
            streetSelected = true;
            Debug.Log(selected.name);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            selected = spawn;
            streetSelected = false;
            Debug.Log(selected.name);
        }

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayLength,layerMask))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Tile":
                        Debug.Log(hit.collider.transform.position);
                        GameObject go = Instantiate(selected, hit.collider.transform.position, hit.collider.transform.rotation);
                        //go.transform.parent = hit.collider.transform.parent;
                        if (streetSelected)
                        {
                            go.transform.parent = street.transform;
                            go.name = hit.collider.gameObject.name;
                        }
                        Destroy(hit.collider.transform.gameObject);
                        break;
                    case "CreateManager":
                        hit.collider.gameObject.GetComponent<CreateManager>().StreetLoader(street);
                        break;
                }
            }
        }
    }
}
