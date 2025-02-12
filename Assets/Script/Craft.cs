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
            new Item("Rocket", new Dictionary<string, int>{ { "RocketFlame", 20 }, { "Iron", 20 } }),
            new Item("CopperWire", new Dictionary<string, int> { { "Copper", 3} }),
            new Item("CircuitBoard", new Dictionary<string, int>{{"CopperWire", 3}, { "Iron", 1} }),
            new Item("UpgradeParts", new Dictionary<string, int> { { "CircuitBoard", 5 }, { "Iron", 10 }}),
            new Item("MiningUpgrade", new Dictionary<string, int> {{"UpgradeParts", 5},{"CircuitBoard",5} }),
            new Item("IronGearWheel", new Dictionary<string, int> {{"Iron", 2}}),
            new Item("AutoMiner", new Dictionary<string, int>{ { "CircuitBoard", 5 },{"IronGearWheel", 3 },{"Iron", 10 } })
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
            _inventory.AddItem(itemName, 1);
            PlayerSoundManager.instance.PlayCraftSound();
        }
        else
        {
            LogToUI.Instance.ShowDebugLog($"{itemName}ÇçÏÇÈÇΩÇﬂÇÃëfçﬁÇ™Ç†ÇËÇ‹ÇπÇÒ"); 
            PlayerSoundManager.instance.PlayMissCraftSound();
        }
    }
}

