using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (true)
        {
            Debug.Log("touch");
        }
    }
}
