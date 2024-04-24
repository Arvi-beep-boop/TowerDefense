using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public int count; //Item count
        public int maxAllowed; //Max item count allowed in a slot
        public ItemType type;
        public Sprite icon;

        public Slot()
        {
            type = ItemType.NONE;
            count = 0;
            maxAllowed = 16;
        }

        public bool CanAddItem()
        {
            if(count >= maxAllowed)
            {
                return false;
            }
            return true;
        }
        public void AddItem(Item itemToAdd)
        {
            count++;
            this.type = itemToAdd.type;
            this.icon = itemToAdd.itemIcon;
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for(int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void AddItem(Item itemToAdd)
    {
        // if item is already in the inventory
        foreach(Slot slot in slots)
        {
            if(slot.type == itemToAdd.type && slot.CanAddItem())
            {
                slot.AddItem(itemToAdd);
            }
        }
        // if item is not in the inventory
        foreach(Slot slot in slots)
        {
            if (slot.type == ItemType.NONE)
            {
                slot.AddItem(itemToAdd);
                return;
            }
        }
    }
}
