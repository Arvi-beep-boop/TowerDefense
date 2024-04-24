using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory_UI : MonoBehaviour
{
    public GameObject InventoryPanel;
    public Player player;

    public List<Slots_UI> slots = new List<Slots_UI>();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }
    public void ToggleInventory()
    {
        if(!InventoryPanel.activeSelf)
        {
            InventoryPanel.SetActive(true);
            Setup();
        }
        else
        { 
            InventoryPanel.SetActive(false); 
        }
    }

    void Setup()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].type != ItemType.NONE)
                {
                    // set Icon & Quantity
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }
}
