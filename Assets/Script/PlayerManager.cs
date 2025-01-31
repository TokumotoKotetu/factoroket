using TMPro;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerManager : MonoBehaviour
{
    Vector3 _moveInput = new Vector3 (0, 0, 0);
    [SerializeField] float _moveSpeed = 5f;
    bool _isIronMine = false;
    bool _isCopperMine = false;
    Rigidbody _rigidbody;
    float _timer = 0;
    [SerializeField] float _miningCooldown = 1f;
    public Inventory _inventory;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.z = Input.GetAxisRaw("Vertical");

        if (_isIronMine)
        {
            IronMine();
        }
        if(_isCopperMine)
        {
            CopperMine();
        }

        _timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("“S‚Ì”:" + _inventory.Iron + ",“º‚Ì”:" + _inventory.Copper);
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        //transform.position = transform.position + _moveInput.normalized * _moveSpeed * Time.deltaTime;
        //_rigidbody.velocity = _moveInput.normalized * _moveSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + _moveInput.normalized * _moveSpeed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "IronOre")
        {
            _isIronMine = true;
        }
        else if(other.tag == "CopperOre")
        {
            _isCopperMine = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "IronOre")
        {
            _isIronMine = false;
        }
        else if(other.tag == "CopperOre")
        {
            _isCopperMine = false;
        }
    }


    void IronMine()
    {
        if(_timer > _miningCooldown)
        {
            _inventory.Iron += 1;
            _timer = 0;
        }
    }

    void CopperMine()
    {
        if(_timer > _miningCooldown)
        {
            _inventory.Copper += 1;
            _timer = 0;
        }
    }
}
