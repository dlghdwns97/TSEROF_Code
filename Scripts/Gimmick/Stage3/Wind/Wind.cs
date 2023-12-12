using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float xdir;
    public float ydir;
    public float zdir;
    public float windpower;

    public bool useForce;
    public bool useVelocity;
    private void OnTriggerStay(Collider other)
    {
        ForceReceiver forceReceiver = other.gameObject.GetComponent<ForceReceiver>();
        if (useForce)
        {
            if (forceReceiver != null)
                forceReceiver.StartGimmick(Gimmicks.AddForce, other.attachedRigidbody, xdir, ydir, zdir, windpower);
        }
        else if (useVelocity)
        {
            if (forceReceiver != null)
                forceReceiver.StartGimmick(Gimmicks.AddVelocity, other.attachedRigidbody, xdir, ydir, zdir, 0);
        }
        else return;
    }
}
