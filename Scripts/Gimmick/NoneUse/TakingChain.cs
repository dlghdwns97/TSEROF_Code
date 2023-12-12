using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingChain : MonoBehaviour
{
    // private bool _isRope = false;

    [SerializeField]
    private FixedJoint _fj;

    private void Awake()
    {
        _fj = GetComponent<FixedJoint>();
        _fj.connectedBody = null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _fj.connectedBody = null;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Chain"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            _fj.connectedBody = rb;
            // _isRope = true;
        }
    }
}
