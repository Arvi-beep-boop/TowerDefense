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
        if (selectedTurret != null)
        {
            UpdateMaterials();

            selectedTurret.transform.position = postion;
            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                PlaceObject();
            }
            if (Input.GetMouseButtonDown(1) && selectedTurret != null)
            {
                Destroy(selectedTurret.gameObject);
                // TO DO: HANDLE CANCELING THE PLACEMENT/BUYING, return money or smth
            }
            if (Input.GetKeyDown(KeyCode.R)) { RotateObject(); }

        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            if (selectedTurret)
            {
                postion = new Vector3(hit.point.x, selectedTurret.GetComponent<Renderer>().localBounds.max.y, hit.point.z);
            }
            else
            {
                postion = hit.point;
            }
        }
    }


    public void SelectObject(int index)
    {
        if (selectedTurret) return;
        selectedTurret = Instantiate(turrets[index], postion, transform.rotation);
        if (selectedTurret.TryGetComponent<Turret>(out Turret turret))
            turret.canShooting = false;
        Debug.Log("object selected");
    }

    public void PlaceObject()
    {
        selectedTurret.GetComponent<MeshRenderer>().material = materials[2];
        if (selectedTurret.TryGetComponent<Turret>(out Turret turret))
            turret.canShooting = true;
        selectedTurret = null;
    }
    private void RotateObject()
    {
        selectedTurret.transform.Rotate(Vector3.up, rotation);
    }
    void UpdateMaterials()
    {
        if (canPlace)
        {
            selectedTurret.GetComponent<MeshRenderer>().material = materials[0];
        }
        else
        {
            selectedTurret.GetComponent<MeshRenderer>().material = materials[1];
        }
    }
}
