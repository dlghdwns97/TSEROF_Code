using UnityEngine;

public class FrontWind : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        ForceReceiver forceReceiver = other.gameObject.GetComponent<ForceReceiver>();
        if (forceReceiver != null)
        {
            forceReceiver.StartGimmick(Gimmicks.AddForce, other.attachedRigidbody, 0, 0, 1, 400f);
        }
    }
}
