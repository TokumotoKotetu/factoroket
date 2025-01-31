using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField] GameObject IronText;
    [SerializeField] GameObject CopperText;
    public Inventory _inventory;
    Text _ironText;
    Text _copperText;

    private void Start()
    {
        _ironText = IronText.GetComponent<Text>();
        _ironText.text = "“S:" + _inventory.Iron.ToString();
        _copperText = CopperText.GetComponent<Text>();
        _copperText.text = "“º;" + _inventory.Copper.ToString();
    }

    private void Update()
    {
        _ironText.text = "“S:" + _inventory.Iron.ToString();
        _copperText.text = "“º;" + _inventory.Copper.ToString();
    }
}
