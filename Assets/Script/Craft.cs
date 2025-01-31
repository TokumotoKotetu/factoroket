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
            //�K�v�f�ނ����炷
            _inventory.Iron -= resources["Iron"].required;
            _inventory.Copper -= resources["Copper"].required;
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
