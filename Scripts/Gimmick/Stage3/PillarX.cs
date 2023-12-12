using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class PillarX : MonoBehaviour
{
    [SerializeField] private GameObject _pillar;
    [SerializeField] private GameObject _gimmickForObject;
    [SerializeField] private GameObject _target;

    private Vector3 _pillarpos;
    public float pillarspeed;
    public float outCooldown;
    public float inCooldown;

    private void Awake()
    {
        _pillarpos = _pillar.transform.position;
    }
    private void Start()
    {
        if (_pillar.transform.position.x < _target.transform.position.x)
            StartCoroutine(MovePillarToRight(outCooldown, inCooldown));
        else if (_pillar.transform.position.x == _target.transform.position.x)
            return;
        else
            StartCoroutine(MovePillarToLeft(outCooldown, inCooldown));
    }
    private IEnumerator MovePillarToRight(float OutCooldown, float InCooldown)
    {
        while (_pillar != null)
        {
            while (_pillar.transform.position.x >= _pillarpos.x && _pillar.transform.position.x < _target.transform.position.x)
            {
                _gimmickForObject.GetComponent<GimmickForObject>().MovingObjectWithMoveTowards(_pillar, _target.transform.position, pillarspeed * 2f);
                yield return 0;
            }
            yield return new WaitForSecondsRealtime(OutCooldown);

            while (_pillar.transform.position.x <= _target.transform.position.x && _pillar.transform.position.x > _pillarpos.x)
            {
                _gimmickForObject.GetComponent<GimmickForObject>().MovingObjectWithMoveTowards(_pillar, _pillarpos, pillarspeed);
                yield return 0;
            }
            yield return new WaitForSecondsRealtime(InCooldown);
        }
    }
    private IEnumerator MovePillarToLeft(float OutCooldown, float InCooldown)
    {
        while (_pillar != null)
        {
            while (_pillar.transform.position.x <= _pillarpos.x && _pillar.transform.position.x > _target.transform.position.x)
            {
                _gimmickForObject.GetComponent<GimmickForObject>().MovingObjectWithMoveTowards(_pillar, _target.transform.position, pillarspeed * 2f);
                yield return 0;
            }
            yield return new WaitForSecondsRealtime(OutCooldown);

            while (_pillar.transform.position.x >= _target.transform.position.x && _pillar.transform.position.x < _pillarpos.x)
            {
                _gimmickForObject.GetComponent<GimmickForObject>().MovingObjectWithMoveTowards(_pillar, _pillarpos, pillarspeed);
                yield return 0;
            }
            yield return new WaitForSecondsRealtime(InCooldown);
        }
    }
}
