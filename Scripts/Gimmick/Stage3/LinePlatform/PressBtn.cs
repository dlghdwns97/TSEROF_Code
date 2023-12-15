using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressBtn : GimmickForObject
{
    public GameObject btn;
    public float xdir;
    public float ydir;
    public float zdir;

    [SerializeField] private GameObject _gimmickForObject;
    private void OnTriggerStay(Collider other)
    {
        ForceReceiver forceReceiver = other.gameObject.GetComponent<ForceReceiver>();
        
        if (forceReceiver != null && other.CompareTag("Player"))
        {
            MovingObjectWithVelocity(btn, xdir, ydir, zdir);
            other.gameObject.transform.SetParent(btn.transform.parent);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            MovingObjectWithVelocity(btn, 0, 0, 0);;
            other.gameObject.transform.SetParent(null);
        }
    }
    public override void MovingObjectWithVelocity(GameObject obj, float x, float y, float z)
    {
        if (obj != null)
            obj.GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);
    }
}
