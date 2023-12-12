using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRespawn : MonoBehaviour
{
    public GameObject platform;

    [SerializeField] private Respawn _respawn;
    private void Update()
    {
        if (_respawn.isRespawn)
        {
            platform.transform.localPosition = new Vector3(0, 6.5f, 39);
            _respawn.isRespawn = false;
        }
    }
}
