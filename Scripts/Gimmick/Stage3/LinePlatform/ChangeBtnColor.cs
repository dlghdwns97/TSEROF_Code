using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBtnColor : MonoBehaviour
{
    public GameObject btn;
    public Material[] mat = new Material[2];
    private void Awake()
    {
        btn.GetComponent<MeshRenderer>().material = mat[0];
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && btn.GetComponent<MeshRenderer>() != null)
        {
            btn.GetComponent<MeshRenderer>().material = mat[1];
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && btn.GetComponent<MeshRenderer>() != null)
        {
            btn.GetComponent<MeshRenderer>().material = mat[0];
        }
    }
}
