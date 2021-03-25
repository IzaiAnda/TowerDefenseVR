using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public bool creative = false;

    public float rayLength = 100;
    public LayerMask layerMask;
    public GameObject baseTurr;
    public GameObject tile;
    public GameObject castle;
    public GameObject wP;
    GameObject selected;
    public GameObject spawn;
    GameObject street;
    bool streetSelected = false;
    bool castleSelected = false;

    private void Awake()
    {
        selected = tile;
        street = new GameObject();
        street.name = "street";
    }

    // Update is called once per frame
    void Update()
    {
        if(creative){
            if (Input.GetKeyDown(KeyCode.U))
            {
                selected = baseTurr;
                Debug.Log(selected.name);
                streetSelected = false;
                castleSelected = false;

            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                if (!GameObject.Find("Casttle(Clone)"))
                {
                    selected = castle;
                    streetSelected = false;
                    Debug.Log(selected.name);
                    castleSelected = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                selected = wP;
                streetSelected = true;
                castleSelected = false;
                Debug.Log(selected.name);
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                selected = tile;
                streetSelected = false;
                castleSelected = false;
                Debug.Log(selected.name);
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                selected = spawn;
                streetSelected = false;
                castleSelected = false;
                Debug.Log(selected.name);
            }

            if (Input.GetMouseButtonDown(0)) //&& !EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, rayLength, layerMask))
                {
                    switch (hit.collider.gameObject.tag)
                    {
                        case "Tile":
                            Debug.Log(hit.collider.transform.position);
                            GameObject go = Instantiate(selected, hit.collider.transform.position, hit.collider.transform.rotation);
                            //go.transform.parent = hit.collider.transform.parent;
                            go.GetComponent<Position>().setPosition(hit.collider.gameObject.GetComponent<Position>().x, hit.collider.gameObject.GetComponent<Position>().y);
                            if (streetSelected)
                            {
                                go.transform.parent = street.transform;
                                go.name = hit.collider.gameObject.name;
                            }
                            else if (castleSelected)
                            {
                                selected = tile;
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

        else
        {
             if (Input.GetKeyDown(KeyCode.U))
            {
                selected = baseTurr;
                Debug.Log(selected.name);
                streetSelected = false;
                castleSelected = false;

            }
            if (Input.GetMouseButtonDown(0)) //&& !EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, rayLength, layerMask))
                {
                    switch (hit.collider.gameObject.tag)
                    {
                        case "Tile":
                           // switch(hit.collider.transform.parent)
                            break;

                    }
                }
            }
        }

    }
}
