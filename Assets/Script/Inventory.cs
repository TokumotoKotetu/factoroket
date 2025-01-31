using UnityEngine;

public class Inventory : MonoBehaviour
{
    int _iron;
    int _copper;
    int _roket;
    public int Iron
    {
        get { return _iron; }
        set { _iron = value; }
    }

    public int Copper
    {
        get { return _copper; }
        set { _copper = value;}
    }

    public int Roket
    {
        get { return _roket; }
        set { _roket = value; }
    }
}
