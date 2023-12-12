using UnityEngine;

public class PressBackBtn : MonoBehaviour
{
    public GameObject btn;

    [SerializeField] private GameObject _gimmickForObject;
    private void OnTriggerStay(Collider other)
    {
        ForceReceiver forceReceiver = other.gameObject.GetComponent<ForceReceiver>();
        if (forceReceiver != null && other.CompareTag("Player"))
        {
            _gimmickForObject.GetComponent<GimmickForObject>().MovingParentObjectWithVelocity(btn, 0, 0, -1.5f);
            forceReceiver.StartGimmick(Gimmicks.AddPosition, other.gameObject.GetComponent<Rigidbody>(), 0, 0, -0.03f, 0);
            // TODO : ���� �� �÷��̾� �̵��� ���� ��ǥ �̿��ؼ� �����ϱ�
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
