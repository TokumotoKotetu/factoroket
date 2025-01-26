using UnityEngine;
using UnityEngine.Timeline;

public class PlayerManager : MonoBehaviour
{
    Vector3 _moveInput = new Vector3 (0, 0, 0);
    [SerializeField] float _moveSpeed = 5f;
    bool _isSpace = false;
    Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.z = Input.GetAxisRaw("Vertical");
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
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isSpace = true;
        }
    }
}
