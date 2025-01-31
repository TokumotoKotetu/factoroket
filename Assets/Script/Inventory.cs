using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int _iron;
    
    public int Iron
    {
        get { return _iron; }
        set { _iron = value; }
    }
}
