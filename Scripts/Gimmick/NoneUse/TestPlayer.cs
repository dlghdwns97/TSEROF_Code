using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    private float _jumpForce = 5f;
    private float _speed = 5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float fallSpeed = _rb.velocity.y;

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= _speed;
        velocity.y = fallSpeed;
        _rb.velocity = velocity;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
