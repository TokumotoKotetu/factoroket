using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Craft : MonoBehaviour
{
    public Inventory _inventory;


    void Start()
    {

        var materials = new Dictionary<string, (int current, int required)>
        {
            { "Iron", (_inventory.Iron , 100)},
            { "Copper" , (_inventory.Copper , 100) }
        };

    }

    private void Update()
    {

    }

    public void CraftRoket(Dictionary<string, (int current, int required)> resources) 
    {
        if (resources.Values.All(resources => resources.current >= resources.required))
        {
            //必要素材を減らす
            _inventory.Iron -= resources["Iron"].required;
            _inventory.Copper -= resources["Copper"].required;
            //作成時間
            //アイテム入手
            _inventory.Roket += 1;
            Debug.Log("ロケットを作りました");
        }
        else
        {
            Debug.Log("必要素材が足りません");
        }

    }
}
