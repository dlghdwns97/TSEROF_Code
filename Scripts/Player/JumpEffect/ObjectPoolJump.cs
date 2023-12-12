using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolJump : MonoBehaviour
{
    public static ObjectPoolJump Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    Queue<JumpEffect> poolingObjectQueue = new Queue<JumpEffect>();

    private void Awake()
    {
        Instance = this;

        Initialize(6);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private JumpEffect CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<JumpEffect>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static JumpEffect GetObject()
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(JumpEffect obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
