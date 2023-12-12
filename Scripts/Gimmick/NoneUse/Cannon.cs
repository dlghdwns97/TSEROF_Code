using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float deg; //����
    public float turnSpeed;//���� ���ǵ�
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
        if (Input.GetKey(KeyCode.E))  //eŰ�� ������ 
        {
            deg = deg + Time.deltaTime * turnSpeed;  //������ �����Ѵ�.
            float rad = deg * Mathf.Deg2Rad;  // �� ������ ������ �����ֱ�         
            turret.transform.eulerAngles = new Vector3(deg, -12.73f, 0);  // ���� ���߱�
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
        if (Input.GetKey(KeyCode.R))  //rŰ�� ������ ������ �����ϱ�
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
        if (Input.GetKeyDown(KeyCode.Y))  //yŰ�� ���� �� �� �ִ��� �������� �����Ѵ�.
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
        if (Input.GetKeyDown(KeyCode.T) && _isInside)   //���� �ȿ� �� �ְ� tŰ�� ������ Ż �� �ִٴ� ���̴�
        {
            _isRide = !_isRide;
        }
        if (_isRide) //Ż �� �ִٸ� Ÿ��
        {
            player.ForceReceiver.ignorePlayerStatus = true;
            player.ForceReceiver.EnterGround();
            player.GetComponent<Transform>().position = CannonPos.position; //��ġ�� �����ǰ� ��ġ��Ų��.
            player.GetComponent<Transform>().localRotation = CannonPos.transform.rotation;// Quaternion.Euler(deg, 0, 0);
            if (isFly)
            {
                _isRide = !_isRide;  //Ż �� �ְ� ���� ����
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



        yield return new WaitForSeconds(1f); // + ����

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
