using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    bool _isRoketBuilable;

    void Start()
    {
        _isRoketBuilable = false;
    }

    private void Update()
    {

    }

    public void BuildRoket()
    {
        if (_isRoketBuilable)
        {
            //必要素材を減らす

            //作成時間

        }
        else
        {
            Debug.Log("必要素材が足りません");
        }

    }
}
