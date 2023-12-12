using System.Collections.Generic;
using UnityEngine;

public class LogRespawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _logs;

    [SerializeField] private Respawn _respawn;

    private void Start()
    {
        GameObject obj = GameObject.Find("HiddenSpace_2");
        if (obj != null)
        {
            for (int i = 0; i < 4; i++)
            {
                if (obj.transform.GetChild(i) != null)
                    _logs.Add(obj.transform.GetChild(i).gameObject);
            }
        }
    }
    private void Update()
    {
        if (_respawn.isRespawn)
        {
            _respawn.isRespawn = false;
            for (int i = 0; i < 4; i++)
            {
                _logs[i].SetActive(true);
                if (_logs[i].transform.GetChild(0) != null)
                    _logs[i].transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
}
