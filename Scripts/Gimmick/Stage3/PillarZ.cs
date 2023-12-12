using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarZ : MonoBehaviour
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
        if (_pillar.transform.position.z < _target.transform.position.z)
            StartCoroutine(MovePillarToBack(outCooldown, inCooldown));
        else if (_pillar.transform.position.z == _target.transform.position.z)
            return;
        else
            StartCoroutine(MovePillarToFront(outCooldown, inCooldown));
    }
    private IEnumerator MovePillarToBack(float OutCooldown, float InCooldown)
    {
        while (_pillar != null)
        {
            while (_pillar.transform.position.z >= _pillarpos.z && _pillar.transform.position.z < _target.transform.position.z)
            {
                _gimmickForObject.GetComponent<GimmickForObject>().MovingObjectWithMoveTowards(_pillar, _target.transform.position, pillarspeed * 2f);
                yield return 0;
            }
            yield return new WaitForSecondsRealtime(OutCooldown);

            while (_pillar.transform.position.z <= _target.transform.position.z && _pillar.transform.position.z > _pillarpos.z)
            {
                _gimmickForObject.GetComponent<GimmickForObject>().MovingObjectWithMoveTowards(_pillar, _pillarpos, pillarspeed);
                yield return 0;
            }
            yield return new WaitForSecondsRealtime(InCooldown);
        }
    }
    private IEnumerator MovePillarToFront(float OutCooldown, float InCooldown)
    {
        while (_pillar != null)
        {
            while (_pillar.transform.position.z <= _pillarpos.z && _pillar.transform.position.z > _target.transform.position.z)
            {
                _gimmickForObject.GetComponent<GimmickForObject>().MovingObjectWithMoveTowards(_pillar, _target.transform.position, pillarspeed * 2f);
                yield return 0;
            }
            yield return new WaitForSecondsRealtime(OutCooldown);

            while (_pillar.transform.position.z >= _target.transform.position.z && _pillar.transform.position.z < _pillarpos.z)
            {
                _gimmickForObject.GetComponent<GimmickForObject>().MovingObjectWithMoveTowards(_pillar, _pillarpos, pillarspeed);
                yield return 0;
            }
            yield return new WaitForSecondsRealtime(InCooldown);
        }
    }
}
