using UnityEngine;

public class RotationObstacle : MonoBehaviour
{
    public enum Type
    {
        Cogwheel,
        IronMace
    }

    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    private float _speed;

    public Type obstacles;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    public int rotateSpeed;

    public GameObject RotationObject;
    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;

        float elapsedPercentage = _elapsedTime / _timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);//�ѰԿ� �������� �߰��ȴ�
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
        //transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage); //��̸� �ֱ� ���ؼ� �ϴ� ȸ������ �ѹ� �־
        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }
    private void Update()
    {
        //RotationObject.transform.Rotate(Vector3.up * (Time.deltaTime * rotateSpeed));
        Rotation();
    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }

    private void Rotation()
    {
        switch (obstacles)
        {
            case Type.Cogwheel:
                RotationObject.transform.Rotate(Vector3.right * (Time.deltaTime * rotateSpeed));
                break;
            case Type.IronMace:
                RotationObject.transform.Rotate(Vector3.up * (Time.deltaTime * rotateSpeed));
                break;
            default:
                break;

        }
    }
    //
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         //other.transform.SetParent(transform);
    //     }
    // }
    //
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log("ȸ��");
    //     }
    // }
}
