using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GimmickForObject : MonoBehaviour
{
    public virtual void MovingObjectWithForce(GameObject obj, float x, float y, float z, float force)
    {
        if (obj != null)
            obj.GetComponent<Rigidbody>().AddForce((new Vector3(x, y, z)).normalized * force);
    }
    public virtual void MovingParentObjectWithForce(GameObject obj, float x, float y, float z, float force)
    {
        if (obj != null)
            obj.transform.parent.GetComponent<Rigidbody>().AddForce((new Vector3(x, y, z)).normalized * force);
    }
    public virtual void MovingObjectWithVelocity(GameObject obj, float x, float y, float z)
    {
        if (obj != null)
            obj.GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);
    }
    public virtual void MovingParentObjectWithVelocity(GameObject obj, float x, float y, float z)
    {
        if (obj != null)
        {
            obj.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
            obj.transform.parent.GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);
        }
        if (x == 0 && y == 0 && z == 0)
            obj.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
    }
    public virtual void MovingObjectWithMoveTowards(GameObject obj, Vector3 pos, float speed)
    {
        if (obj != null)
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, pos, speed * Time.deltaTime);
    }
    public virtual void SetFalseObject(GameObject obj)
    {
        if (obj != null)
            obj.transform.gameObject.SetActive(false);
    }
    public virtual void SetFalseParentObject(GameObject obj)
    {
        if (obj != null)
            obj.transform.parent.gameObject.SetActive(false);
    }
    public virtual void HideOrRegenObject(GameObject obj, bool isTriggered, bool isMeshrendered)
    {
        if (obj != null)
        {
            obj.GetComponent<Collider>().isTrigger = isTriggered;
            obj.GetComponent<MeshRenderer>().enabled = isMeshrendered;
        }  
    }
    public virtual IEnumerator DefaultCoroutine(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
    }
}
