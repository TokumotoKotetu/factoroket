using System.Collections;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [Tooltip("çÃå@Ç∑ÇÈëfçﬁñº")]
    public string _materialName = "Iron";
    [Tooltip("àÍìxÇ…çÃå@Ç≈Ç´ÇÈó ")]
    public int _amount = 1;
    [Tooltip("çÃå@ä¥äo(ïb)")]
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

                if( _miningCoroutine == null)//çÃå@Ç≥ÇÍÇƒÇ¢Ç»Ç¢èÍçáÇÃÇ›äJén
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
        Debug.Log($"Mining{_materialName}");
        while(_isPlayerNearby )
        {
            yield return new WaitForSeconds( _miningInterval );

            if(_isPlayerNearby && _playerInventory != null)
            {
                _playerInventory.AddItem(_materialName, _amount);
                Debug.Log($"{_materialName}ÇçÃå@:{_amount}(åªç›:{_playerInventory.GetResourceAmount(_materialName)})");
            }
        }
        _miningCoroutine = null;
    }
}
