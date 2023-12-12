using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpWind : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        ForceReceiver forceReceiver = other.gameObject.GetComponent<ForceReceiver>();
        if (forceReceiver != null)
        {
            forceReceiver.StartGimmick(Gimmicks.AddVelocity, other.attachedRigidbody, 0, 0.5f, 0, 0);
        }
    }
}
