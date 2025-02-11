using UnityEngine;

public class Inventory : MonoBehaviour
{
    int _iron;
    int _copper;
    int _rocketFlame;
    int _rocket;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            AddItem("Iron",100);
            AddItem("Copper", 100);
            //AddItem("RocketFlame", 100);
        }
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
            default: Debug.LogWarning("指定された素材がありません"); break;
        }
        Debug.Log($"{resource}を追加:{amount} 現在の{resource}:{GetResourceAmount(resource)}");
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
            default: return 0;
        }
    }
}
