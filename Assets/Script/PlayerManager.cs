using TMPro;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerManager : MonoBehaviour
{
    Vector3 _moveInput = new Vector3 (0, 0, 0);
    [SerializeField] float _moveSpeed = 5f;
    bool _isMine = false;
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

        if (_isMine)
        {
            Mine();
        }

        _timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(_inventory.Iron);
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
            _isMine = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "IronOre")
        {
            _isMine = false;
        }
    }


    void Mine()
    {
        if(_timer > _miningCooldown)
        {
            _inventory.Iron += 1;
            _timer = 0;
        }
    }
}
