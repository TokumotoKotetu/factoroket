using System.Collections;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [Tooltip("採掘する素材名")]
    public string _materialName = "Iron";
    [Tooltip("一度に採掘できる量")]
    public int _amount = 1;
    [Tooltip("採掘感覚(秒)")]
    public float _miningInterval = 3f;

    bool _isPlayerNearby = false;
    Inventory _playerInventory;
    Coroutine _miningCoroutine;

    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerInventory = collision.gameObject.GetComponent<Inventory>();

            if( _playerInventory != null)
            {
                _isPlayerNearby = true;

                if( _miningCoroutine == null)//採掘されていない場合のみ開始
                {
                    _miningCoroutine = StartCoroutine(MineOre());
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isPlayerNearby = false;

            if(_miningCoroutine != null)
            {
                StopCoroutine(_miningCoroutine);
                _miningCoroutine = null;
            }
        }
    }

    IEnumerator MineOre()
    {
        LogToUI.Instance.ShowDebugLog($"Mining{_materialName}");
        _amount = 1 + _playerInventory.MiningUpgrade;
        while(_isPlayerNearby )
        {
            yield return new WaitForSeconds( _miningInterval );

            if(_isPlayerNearby && _playerInventory != null)
            {
                _playerInventory.AddItem(_materialName, _amount);
                LogToUI.Instance.ShowDebugLog($"{_materialName}を採掘:{_amount}(現在:{_playerInventory.GetResourceAmount(_materialName)})");
                PlayerSoundManager.instance.PlayOreMineSound();
            }
        }
        _miningCoroutine = null;
    }
}
