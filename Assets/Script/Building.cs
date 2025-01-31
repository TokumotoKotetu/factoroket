using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Inventory _inventory;
    bool _isRoketBuilable;
    [Header("���P�b�g�ɕK�v�ȑf��")]
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
            //�K�v�f�ނ����炷
            _inventory.Iron -= _ironNeeded;
            //�쐬����
            //�A�C�e������
            _inventory.Roket += 1;
            Debug.Log("���P�b�g�����܂���");
        }
        else
        {
            Debug.Log("�K�v�f�ނ�����܂���");
        }

    }
}
