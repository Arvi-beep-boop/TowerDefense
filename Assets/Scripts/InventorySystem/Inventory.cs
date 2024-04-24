using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TO DO: Move to another script, Item maybe?
public enum ItemType
{
    NONE, SAMPLETYPE
}

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public int count; //Item count
        public int maxAllowed; //Max item count allowed in a slot
        public ItemType type;

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
        public void AddItem(ItemType itemTypeToAdd)
        {
            count++;
            this.type = itemTypeToAdd;
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

    public void AddItem(ItemType itemTypeToAdd)
    {
        // if item is already in the inventory
        foreach(Slot slot in slots)
        {
            if(slot.type == itemTypeToAdd && slot.CanAddItem())
            {
                slot.AddItem(itemTypeToAdd);
            }
        }
        // if item is not in the inventory
        foreach(Slot slot in slots)
        {
            if (slot.type == ItemType.NONE)
            {
                slot.AddItem(itemTypeToAdd);
                return;
            }
        }
    }
}
