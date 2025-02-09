using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Craft : MonoBehaviour
{
    Inventory _inventory;
    public List<Item> _craftableItems;

    void Start()
    {
        _inventory = GetComponent<Inventory>();

        _craftableItems = new List<Item>
        {
            new Item("RocketFlame", new Dictionary<string, int>{ { "Iron", 10 }, { "Copper", 20 } }),
            new Item("Rocket", new Dictionary<string, int>{ { "RocketFlame", 20 }, { "Iron", 20 } })
        };

    }

    void Update()
    {

    }

    public void CraftItem(string itemName)
    {
        Item item = _craftableItems.Find(i => i._name == itemName);
        if(item != null && item.CanCraft(_inventory))
        {
            item.Craft(_inventory);
           //_inventory.AddItem(itemName, 1);
        }
        else
        {
            Debug.Log($"{itemName}ÇçÏÇÈÇΩÇﬂÇÃëfçﬁÇ™Ç†ÇËÇ‹ÇπÇÒ");
        }
    }
}

