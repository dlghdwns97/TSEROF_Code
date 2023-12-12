using UnityEngine;

public class JumpMush : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ForceReceiver forceReceiver = collision.gameObject.GetComponent<ForceReceiver>();
        if (forceReceiver != null)
        {
            forceReceiver.StartGimmick(Gimmicks.AddForce, collision.rigidbody, 0, 1, 0, 300f);
        }
    }
}
