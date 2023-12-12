using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private List<GameObject> _logs = new List<GameObject>();
    [SerializeField] private Vector3[] logpos = new Vector3[LOGS];

    public IEnumerator RegenLogCoroutine;
    public IEnumerator RegenLogCoroutine2;
    public bool isRegen;

    private const int LOGS = 4;
    private const string PLAYER = "Player";
    private void Start()
    {
        for (int i = 0; i < LOGS; i++)
        {
            _logs.Add(gameObject.transform.GetChild(i).gameObject);
            logpos[i] = gameObject.transform.GetChild(i).gameObject.transform.localPosition;
        }
        RegenLogCoroutine = RegenLog();
        isRegen = false;
    }
    public void FallingLog(int index)
    {
        if (_logs[index] != null)
            _logs[index].GetComponent<Rigidbody>().isKinematic = false;
    }
    public IEnumerator RegenLog()
    {
        isRegen = true;
        if (isRegen)
        {
            yield return new WaitForSeconds(7f);
            for (int i = 0; i < LOGS; i++)
            {
                _logs[i].GetComponent<Rigidbody>().isKinematic = true;
                _logs[i].transform.localPosition = logpos[i];
            }
            isRegen = false;
            RegenLogCoroutine = RegenLog();
        }
    }
}
