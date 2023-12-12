using System.Collections;
using UnityEngine;

public class PopBlock : MonoBehaviour
{
    [SerializeField] private GameObject _popBlock;

    [SerializeField] private GameObject _gimmickForObject;

    private void OnCollisionEnter(Collision collision)
    {
        ForceReceiver forceReceiver = collision.gameObject.GetComponent<ForceReceiver>();
        if (_popBlock != null && forceReceiver != null && collision.transform.CompareTag("Player"))
        {
            forceReceiver.StartGimmick(Gimmicks.AddForce, collision.rigidbody, 0, 1, 0, 1000f);
            _gimmickForObject.GetComponent<GimmickForObject>().HideOrRegenObject(_popBlock, true, false);
            StartCoroutine(DelayAndRegen());
        }
    }
    private IEnumerator DelayAndRegen()
    {
        yield return new WaitForSeconds(3.0f);
        _gimmickForObject.GetComponent<GimmickForObject>().HideOrRegenObject(_popBlock, false, true);
    }
}
