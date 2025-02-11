using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string _name;
    public Dictionary<string, int> _requiredMaterials;

    public Item(string name, Dictionary<string, int> requiredMaterials)
    {
        this._name = name;
        this._requiredMaterials = requiredMaterials;
    }

    //作成できるかチェック
    public bool CanCraft(Inventory inventory)
    {
        foreach(var materials in _requiredMaterials)
        {
            if(!inventory.HasEnoughResources(materials.Key, materials.Value))
                return false;
        }
        return true;
    }

    public void Craft(Inventory inventory)
    {
        foreach(var material in _requiredMaterials)
        {
            inventory.UseResource(material.Key, material.Value); 
        }
        Debug.Log($"{_name}を作成しました");
    }
}
