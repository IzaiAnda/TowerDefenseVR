using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaySelectorMouse : MonoBehaviour
{
    public float rayLength;
    public LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayLength,layerMask))
            {
                Debug.Log(hit.collider.transform.position);
            }
        }
    }
}
