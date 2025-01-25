using UnityEngine;

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
        Movement();
    }

    void Movement()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.z = Input.GetAxis("Vertical");

        //transform.position = transform.position + new Vector3(_moveInput.x * _moveSpeed * Time.deltaTime, 0,_moveInput.z * _moveSpeed * Time.deltaTime);
        _rigidbody.velocity = _moveInput.normalized * _moveSpeed * Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isSpace = true;
        }
    }
}
