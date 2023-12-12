using System.Collections;
using UnityEngine;

public enum Cube
{
    Magma,
    Luva,
    Ice,
    Water,
    IceWall
}
public class CubeType : MonoBehaviour
{
    [SerializeField]private Cube _cube;

    [Header("IceCube")]
    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private Vector3 _startRotation;
    [SerializeField] private bool _isMelt;
    [SerializeField] private bool _isRightFalling;


    [Header("Magma")]
    private int _magmaJumpPower;

    float time = 0;

    [Header("임시입니다")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _respwanPos;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
        _startRotation = new Vector3(transform.localRotation.x, 16.976f, transform.localRotation.z);
        StartCoroutine(MagmaCubeMove());
    }
    private void Update()
    {
    }
    private IEnumerator IceMoveStart() //한번만 실행 시킬 수 있는 코루틴 만들어 보기
    {
        float fallingsecond = Random.Range(1, 2);
        if(_isRightFalling)
        {
            fallingsecond = 0.3f;
        }
        yield return new WaitForSeconds(fallingsecond);
        _rigidbody.isKinematic = false;
        yield return new WaitForSeconds(3f);
        if (_isMelt)
        {
            int melt = Random.Range(1, 6);
            if (melt < 4)
            {
                gameObject.SetActive(false);
            }
        }
        _rigidbody.isKinematic = true;
        transform.position = _startPosition;
        transform.localRotation = Quaternion.Euler(_startRotation);
        
    }
    private IEnumerator IceWallMove() //한번만 실행 시킬 수 있는 코루틴 만들어 보기
    {
        
        
        yield return new WaitForSeconds(6f);
        _rigidbody.isKinematic = true;
        transform.position = _startPosition;
        transform.localRotation = Quaternion.Euler(_startRotation);
        yield return new WaitForSeconds(2f);
        _rigidbody.isKinematic = false;
    }

    private IEnumerator MagmaCubeMove() //한번만 실행 시킬 수 있는 코루틴 만들어 보기
    {
        _magmaJumpPower = 10;
        yield return new WaitForSeconds(1.49f);
        var deleyTime = new WaitForSeconds(3.146f);
         //무한 코루틴이기 때문에 가비지를 줄이기 위해서 변수를 초기화 시켜서 사용했습니다.
        while (true)
        {
            _magmaJumpPower = 3;
            yield return deleyTime;
            _magmaJumpPower = 10;
            yield return deleyTime;
        }
    }
    private void SwichPos()  //임시입니다.
    {
        _player.transform.position = _respwanPos.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ForceReceiver forceReceiver = collision.gameObject.GetComponent<ForceReceiver>();
            switch (_cube)
            {
                case Cube.Magma:
                    forceReceiver.StartGimmick(Gimmicks.AddVelocity, collision.gameObject.GetComponent<Rigidbody>(), 0, _magmaJumpPower, 0,30f);               
                    break;
                case Cube.Luva:
                    SwichPos();
                    break;
                case Cube.Ice:
                    StartCoroutine(IceMoveStart());
                    break;
                case Cube.Water:
                    SwichPos();
                    break;
                case Cube.IceWall:
                    StartCoroutine(IceWallMove());
                    break;
                default:
                    break;
            }
        }
    }
}
