using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Tree_Obstacle : MonoBehaviour
{
    [Header("Rotation")]
    public int rotateSpeed;
    public float speedUpTime;
    public int rotateSpeedUp;

    [Header("Object")]
    [SerializeField] private Player player;

    [SerializeField] private Vector3 Power = new Vector3(3,3, 0);
    [SerializeField][Range(0, 20f)] private float Drag = 0.5f;

    Vector3 MovePos;
    private float _curTime;

    private void Start()
    {
        _curTime = 0;
    }

    private void Update()
    {
        Rotate();
        SpeedUp();
        MovePos = transform.GetChild(0).transform.up;
    }

    private void Rotate()
    {
        transform.Rotate(-Vector3.up * (Time.deltaTime * rotateSpeed));
        transform.GetChild(0).Rotate(Vector3.up * (Time.deltaTime * 40 * rotateSpeed));
        transform.GetChild(1).Rotate(Vector3.up * (Time.deltaTime * 40 * rotateSpeed));
    }

    private void SpeedUp()
    {
        _curTime += Time.deltaTime;
        
        if (!(_curTime > speedUpTime))
        {
            return;
        }

        rotateSpeed += rotateSpeedUp;
        _curTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.ForceReceiver.AddVelocity(Power, Drag);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
        Vector3 income = MovePos; // 입사벡터
        //Vector3 direction = Quaternion.AngleAxis(-30, Vector3.forward) *
        Vector3 normal = collision.contacts[0].normal; // 법선벡터
        MovePos = Vector3.Reflect(income, normal).normalized; // 반사
        //player.ForceReceiver.AddVelocity(-player.transform.forward * 20, Drag)
        player.ForceReceiver.AddVelocity(MovePos * 20, Drag);

        }
    }
}
