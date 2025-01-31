using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField] GameObject IronText;
    public Inventory _inventory;
    Text _ironText;
    private void Start()
    {
        _ironText = IronText.GetComponent<Text>();
        _ironText.text = "“S:" + _inventory.Iron.ToString();
    }

    private void Update()
    {
        _ironText.text = "“S:" + _inventory.Iron.ToString();
    }
}
