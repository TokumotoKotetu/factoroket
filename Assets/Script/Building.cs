using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Inventory _inventory;
    bool _isRoketBuilable;
    [Header("ロケットに必要な素材")]
    public int _ironNeeded = 1;


    void Start()
    {
        _isRoketBuilable = false;
    }

    private void Update()
    {
        if(_ironNeeded <= _inventory.Iron)
        {
            _isRoketBuilable = true;
        }
        else
        {
            _isRoketBuilable = false;
        }
    }

    public void BuildRoket()
    {
        if (_isRoketBuilable)
        {
            //必要素材を減らす
            _inventory.Iron -= _ironNeeded;
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
