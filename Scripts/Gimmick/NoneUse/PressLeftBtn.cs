using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressLeftBtn : MonoBehaviour
{
    public GameObject btn;

    [SerializeField] private GameObject _gimmickForObject;

    private void OnTriggerStay(Collider other)
    {
        ForceReceiver forceReceiver = other.gameObject.GetComponent<ForceReceiver>();
        if (forceReceiver != null && other.CompareTag("Player"))
        {
            _gimmickForObject.GetComponent<GimmickForObject>().MovingParentObjectWithVelocity(btn, -1.5f, 0, 0);
            forceReceiver.StartGimmick(Gimmicks.AddPosition, other.gameObject.GetComponent<Rigidbody>(), -0.03f, 0, 0, 0);
            // TODO : 발판 위 플레이어 이동을 발판 좌표 이용해서 구현하기
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            _gimmickForObject.GetComponent<GimmickForObject>().MovingParentObjectWithVelocity(btn, 0, 0, 0);
        }
    }
}
