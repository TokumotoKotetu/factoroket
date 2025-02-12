using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    int _iron;
    int _copper;
    int _rocketFlame;
    int _rocket;
    int _copperWire;
    int _ironGearWheel;
    int _circuitBoard;
    int _upgradeParts;
    int _miningUpgrade;
    int _autoMiner;

    public int Iron
    {
        get { return _iron; }
        private set { _iron = Mathf.Max(0, value); }
    }

    public int Copper
    {
        get { return _copper; }
        private set { _copper = Mathf.Max(0, value); }
    }

    public int RocketFlame
    {
        get { return _rocketFlame; }
        private set { _rocketFlame = Mathf.Max(0, value); }
    }
    public int Rocket
    {
        get { return _rocket; }
        private set { _rocket = Mathf.Max(0, value); }
    }

    public int CopperWire
    {
        get { return _copperWire; }
        private set { _copperWire = Mathf.Max(0, value); }
    }

    public int IronGearWheel
    {
        get { return _ironGearWheel; }
        private set { _ironGearWheel = Mathf.Max(0, value); }
    }

    public int CircuitBoard
    {
        get { return _circuitBoard; }
        private set { _circuitBoard = Mathf.Max(0, value); }
    }

    public int UpgradeParts
    {
        get { return _upgradeParts; }
        private set { _upgradeParts = Mathf.Max(0, value); }
    }

    public int MiningUpgrade
    {
        get { return _miningUpgrade; }
        private set { _miningUpgrade = Mathf.Max(0, value);}
    }

    public int AutoMiner
    {
        get { return _autoMiner; }
        private set { _autoMiner = Mathf.Max(0, value); }

    }
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.I))
        {
            AddItem("Iron",100);
            AddItem("Copper", 100);
            AddItem("IronGearWheel", 100);
            AddItem("CopperWire", 100);
            AddItem("CircuitBoard", 100);
            AddItem("UpgradeParts", 100);
            AddItem("RocketFlame", 100);
        }
#endif
    }

    //アイテムを追加

    public void AddItem(string resource, int amount)
    {
        switch (resource)
        {
            case "Iron": Iron += amount; break;
            case "Copper": Copper += amount; break;
            case "RocketFlame": RocketFlame += amount; break;
            case "Rocket": Rocket += amount; break;
            case "CopperWire": CopperWire += amount; break;
            case "IronGearWheel":IronGearWheel += amount; break;
            case "CircuitBoard": CircuitBoard += amount; break;
            case "UpgradeParts": UpgradeParts += amount; break;
            case "MiningUpgrade": MiningUpgrade += amount; break;
            case "AutoMiner": AutoMiner += amount; break;
            default: LogToUI.Instance.ShowDebugLog("指定された素材がありません"); break;
        }
        //LogToUI.Instance.ShowDebugLog($"{resource}を追加:{amount} 現在の{resource}:{GetResourceAmount(resource)}");
        //PlayerSoundManager.instance.PlayGetItemSound();
    }


    //必要な資源が足りているか確認
    public bool HasEnoughResources(string resource, int requiredAmount)
    {
        switch (resource)
        {
            case "Iron": return Iron >= requiredAmount;
            case "Copper": return Copper >= requiredAmount;
            case "RocketFlame": return RocketFlame >= requiredAmount;
            case "Rocket": return Rocket >= requiredAmount;
            case "CopperWire": return CopperWire >= requiredAmount;
            case "IronGearWheel": return IronGearWheel >= requiredAmount;
            case "CircuitBoard": return CircuitBoard >= requiredAmount;
            case "UpgradeParts": return UpgradeParts >= requiredAmount;
            case "MiningUpgrade":return MiningUpgrade >= requiredAmount;
            case "AutoMiner": return AutoMiner >= requiredAmount;
            default: return false;
        }
    }

    //資源を減らす
    public void UseResource(string resource, int amount)
    {
        switch (resource)
        {
            case "Iron": Iron -= amount; break;
            case "Copper": Copper -= amount; break;
            case "RocketFlame": RocketFlame -= amount; break;
            case "Rocket": Rocket -= amount; break;
            case "CopperWire": CopperWire -= amount; break;
            case "IronGearWheel":IronGearWheel -= amount; break;
            case "CircuitBoard": CircuitBoard -= amount; break;
            case "UpgradeParts": UpgradeParts -= amount; break;
            case "MiningUpgrade":MiningUpgrade -= amount; break;
            case "AutoMiner":AutoMiner -= amount; break;
        }
    }

    //素材の量を返す
    public int GetResourceAmount(string resource)
    {
        switch(resource)
        {
            case "Iron": return Iron;
            case "Copper": return Copper;
            case "RocketFlame": return RocketFlame;
            case "Rocket": return Rocket;
            case "CopperWire": return CopperWire;
            case "IronGearWheel": return IronGearWheel;
            case "CircuitBoard":return CircuitBoard;
            case "UpgradeParts":return UpgradeParts;
            case "MiningUpgrade": return MiningUpgrade;
            case "AutoMiner": return AutoMiner;
            default: return 0;
        }
    }
}
