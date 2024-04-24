using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory_UI : MonoBehaviour
{
    public GameObject InventoryPanel;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }
    void ToggleInventory()
    {
        if(!InventoryPanel.activeSelf)
        {
            InventoryPanel.SetActive(true);
        }
        else
        { 
            InventoryPanel.SetActive(false); 
        }
    }
    public void CloseInventoryButton() { InventoryPanel.SetActive(false); }
}
