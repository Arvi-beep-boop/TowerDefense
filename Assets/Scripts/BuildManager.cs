using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public GameObject[] turrets;
    
    private GameObject selectedTurret;
    private Vector3 postion;
    private RaycastHit hit;

    [SerializeField] private LayerMask layerMask;
    
    
    void Update()
    {
       if(selectedTurret != null)
       {
            selectedTurret.transform.position = postion;
            if(Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }
       }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layerMask)) 
        {
            postion = hit.point;
        }
    }

    public void SelectObject(int index)
    {
        selectedTurret = Instantiate(turrets[index], postion, transform.rotation);
    }

    public void PlaceObject()
    {
        selectedTurret = null;
    }
}
