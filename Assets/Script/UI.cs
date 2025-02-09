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
        _ironText.text = "�S:" + _inventory.Iron.ToString();
        _copperText.text = "��:" + _inventory.Copper.ToString();
        _rocketFlameText.text = "���P�b�g�t���[��:" + _inventory.RocketFlame.ToString();
    }
}
