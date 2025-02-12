using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField] GameObject IronText;
    [SerializeField] GameObject CopperText;
    [SerializeField] GameObject RocketFlameText;
    [SerializeField] GameObject CopperWireText;
    [SerializeField] GameObject IronGearText;
    [SerializeField] GameObject CircuitBoardText;
    [SerializeField] GameObject UpgradePartsText;
    [SerializeField] GameObject MiningUpgradeText;
    [SerializeField] GameObject AutoMinerText;


    public Inventory _inventory;
    Text _ironText;
    Text _copperText;
    Text _rocketFlameText;
    Text _copperWireText;
    Text _circuitBoardtext;
    Text _upgradePartsText;
    Text _miningUpgradeText;
    Text _ironGearText;
    Text _autoMinerText;

    private void Start()
    {
        _ironText = IronText.GetComponent<Text>();
        _copperText = CopperText.GetComponent<Text>();
        _rocketFlameText = RocketFlameText.GetComponent<Text>();
        _copperWireText = CopperWireText.GetComponent<Text>();
        _circuitBoardtext = CircuitBoardText.GetComponent<Text>();
        _upgradePartsText = UpgradePartsText.GetComponent<Text>();
        _miningUpgradeText = MiningUpgradeText.GetComponent<Text>();
        _ironGearText = IronGearText.GetComponent<Text>();
        _autoMinerText = AutoMinerText.GetComponent<Text>();
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
        _copperWireText.text = "銅線:" + _inventory.CopperWire.ToString();
        _circuitBoardtext.text = "回路基板:" + _inventory.CircuitBoard.ToString();
        _upgradePartsText.text = "アップグレードパーツ:" + _inventory.UpgradeParts.ToString();
        _miningUpgradeText.text = "採掘力:" + (1 + _inventory.MiningUpgrade).ToString();
        _ironGearText.text = "鉄の歯車:" + _inventory.IronGearWheel.ToString();
        _autoMinerText.text = "自動採掘数:" + _inventory.AutoMiner.ToString();
    }
}
