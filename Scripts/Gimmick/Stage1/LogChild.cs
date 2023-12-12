using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogChild : MonoBehaviour
{
    [SerializeField] private GameObject _logs;
    public int logindex;

    private const string PLAYER = "Player";
    private void OnCollisionEnter(Collision collision)
    {
        if (_logs != null && collision.collider.CompareTag(PLAYER))
            _logs.GetComponent<Log>().FallingLog(logindex);

        if (!_logs.GetComponent<Log>().isRegen && _logs != null && collision.collider.CompareTag(PLAYER))
            StartCoroutine(_logs.GetComponent<Log>().RegenLogCoroutine);
    }
}
