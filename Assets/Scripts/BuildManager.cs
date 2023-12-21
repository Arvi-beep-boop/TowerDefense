using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public GameObject[] turrets;
    public bool canPlace = true;
    private GameObject selectedTurret;
    private Vector3 postion;
    private RaycastHit hit;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float rotation; // in degrees
    [SerializeField] private Material[] materials;

    void Update()
    {
       if(selectedTurret != null)
       {
            UpdateMaterials();

            selectedTurret.transform.position = postion;
            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceObject();
            }
            if (Input.GetKeyDown(KeyCode.R)) { RotateObject(); }
            
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
        selectedTurret.GetComponent<MeshRenderer>().material = materials[2];
        selectedTurret = null;
    }
    private void RotateObject()
    {
        selectedTurret.transform.Rotate(Vector3.up, rotation);
    }
    void UpdateMaterials()
    {
        if(canPlace)
        {
            selectedTurret.GetComponent<MeshRenderer>().material = materials[0];
        }
        else
        {
            selectedTurret.GetComponent<MeshRenderer>().material = materials[1];
        }
    }
}
