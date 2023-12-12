using UnityEngine;

public class Hammer : MonoBehaviour
{
    [Header("Rotation")]
    public int rotateSpeed;
    public float speedUpTime;
    public int rotateSpeedUp;
    private float curTime;
    private void Start()
    {
        curTime = 0;
    }

    private void Update()
    {
        Rotate();
        SpeedUp();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime), Space.World);

    }

    private void SpeedUp()
    {
        curTime += Time.deltaTime;
        if (!(curTime > speedUpTime))
        {
            return;
        }

        rotateSpeed += rotateSpeedUp;
        curTime = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("데미지를 입었다");
        }
    }
}
