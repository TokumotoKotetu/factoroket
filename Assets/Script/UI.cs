using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField] GameObject IronText;
    [SerializeField] GameObject CopperText;
    [SerializeField] GameObject RocketFlameText;

    public Inventory _inventory;
    Text _ironText;
    Text _copperText;
    Text _rocketFlameText;

    private void Start()
    {
        _ironText = IronText.GetComponent<Text>();
        _copperText = CopperText.GetComponent<Text>();
        _rocketFlameText =RocketFlameText.GetComponent<Text>();

        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        _ironText.text = "鉄:" + _inventory.Iron.ToString();
        _copperText.text = "銅:" + _inventory.Copper.ToString();
        _rocketFlameText.text = "ロケットフレーム:" + _inventory.RocketFlame.ToString();
    }
}
