using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float deg; //각도
    public float turnSpeed;//대포 스피드
    public GameObject turret;
    public Player player;
    Rigidbody rb;
    public Transform CannonPos;
    public Transform CannonRot;
    private bool _isRide;
    public bool merong { get; private set; }
    bool _isInside;
    bool isFly;

    public Vector3 cannonVelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpCannon();
        DownCannom();
        Ride();
        CheckIsFly();
        Fly();
    }

    private void FixedUpdate()
    {
       // Fly();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInside = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isInside = false;
            //isFly = false;
           // player.isTurnXZ = false;
        }
    }

    void UpCannon()
    {
        if (Input.GetKey(KeyCode.E))  //e키를 누르면 
        {
            deg = deg + Time.deltaTime * turnSpeed;  //각도를 조정한다.
            float rad = deg * Mathf.Deg2Rad;  // 그 각도의 정도를 맞춰주기         
            turret.transform.eulerAngles = new Vector3(deg, -12.73f, 0);  // 각도 맞추기
            if (deg > 30)
            {
                deg = 30;
            }
            else if (deg < -30)
            {
                deg = -30;
            }
        }
    }

    void DownCannom()
    {
        if (Input.GetKey(KeyCode.R))  //r키를 누리면 각도를 조절하기
        {
            deg = deg - Time.deltaTime * turnSpeed;
            float rad = deg * Mathf.Deg2Rad;
            turret.transform.eulerAngles = new Vector3(deg, -12.73f, 0);
            if (deg > 30)
            {
                deg = 30;
            }
            else if (deg < -30)
            {
                deg = -30;
            }
        }
    }

    void CheckIsFly()
    {
        if (Input.GetKeyDown(KeyCode.Y))  //y키를 통해 날 수 있는지 없는지를 조절한다.
        {
            isFly = true;
        }
    }

    void Fly()
    {
        if (isFly)
        {
            // LotateStartCoroutine();
            FlyStart();
            isFly = false;
        }
    }

    void Ride()
    {
        if (Input.GetKeyDown(KeyCode.T) && _isInside)   //만약 안에 들어가 있고 t키가 눌리면 탈 수 있다는 것이다
        {
            _isRide = !_isRide;
        }
        if (_isRide) //탈 수 있다면 타고
        {
            player.ForceReceiver.ignorePlayerStatus = true;
            player.ForceReceiver.EnterGround();
            player.GetComponent<Transform>().position = CannonPos.position; //위치를 포지션과 일치시킨다.
            player.GetComponent<Transform>().localRotation = CannonPos.transform.rotation;// Quaternion.Euler(deg, 0, 0);
            if (isFly)
            {
                _isRide = !_isRide;  //탈 수 있고 없고를 가림
            }
        }

    }

    public void FlyStart()
    {
        player.ForceReceiver.ignorePlayerStatus = false;
        player.ForceReceiver.EnterAir();
        player.ForceReceiver.AddVelocity(cannonVelocity);
    }

    public IEnumerator FlyStart1()
    {
        
        player.ForceReceiver.SetVelocity(x: 3, y: 3, z: 3);



        yield return new WaitForSeconds(1f); // + 조건

        player.ForceReceiver.SetVelocity(0, 0, 0);
        player.ForceReceiver.ignorePlayerStatus = false;

    }
    //
    // public void LotateStartCoroutine()
    // {
    //
    //     StartCoroutine(FlyStart());
    // }

}
