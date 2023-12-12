using UnityEngine;

public class RotationCube : MonoBehaviour
{
    void Update()
    {
        Rotation();
    }
    
    private void Rotation()
    {
       transform.Rotate(Vector3.right * (Time.deltaTime * 50));       
    }
}
