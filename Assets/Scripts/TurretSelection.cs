using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TurretSelection : MonoBehaviour
{
    public GameObject selectedObject;
    public Material selectMaterial;
    public Material afterMaterial; //just for now

    [SerializeField] private Text displayText;
    [SerializeField] private Image displayImage;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000))
            {
                if(hit.collider.gameObject.CompareTag("Turret"))
                {
                    Select(hit.collider.gameObject);
                }
            }
        }
        if(Input.GetMouseButtonDown(1) && selectedObject)
        {
            Deselect();
        }
    }

    private void Select(GameObject objToSelect)
    {
        if(objToSelect == selectedObject) { return; }
        if(selectedObject != null) { Deselect(); }

        // maybe consider outline or some visual effects
        selectedObject = objToSelect;
        selectedObject.gameObject.GetComponent<Renderer>().material = selectMaterial;
        ShowDisplay();

    }

    public void Deselect()
    {
        selectedObject.gameObject.GetComponent<Renderer>().material = afterMaterial;
        selectedObject = null;
        ClearDisplay();
    }

    public void ShowSelectedName()
    {
        displayText.text = selectedObject.name;
    }

    public void ClearSelectedName() 
    {
        displayText.text = string.Empty;
    }

    public void RemoveTurret()
    {
        Destroy(selectedObject.gameObject);
        selectedObject = null;
        ClearDisplay();
    }

    public void ShowImage()
    {
       displayImage.sprite = selectedObject.GetComponent<Displays>().sprite;
    }
    public void HideImage()
    {
        displayImage.sprite = null;
    }

    public void ClearDisplay()
    {
        ClearSelectedName();
        HideImage();
    }

    public void ShowDisplay()
    {
        ShowImage();
        ShowSelectedName();
    }
}
