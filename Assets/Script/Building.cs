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
            //�K�v�f�ނ����炷

            //�쐬����

        }
        else
        {
            Debug.Log("�K�v�f�ނ�����܂���");
        }

    }
}
