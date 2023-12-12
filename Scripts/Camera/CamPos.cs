using UnityEngine;

public class CamPos : MonoBehaviour
{
    [Header("Object")]
    public GameObject player;

    [Header("Position")]
    private Vector3 _camPosition;
    private float _startPlayerY;  
    private void Start()
    {
        _camPosition = transform.position;
        _startPlayerY = player.transform.position.y;
    }

    private void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position,
            _camPosition + new Vector3(0, player.transform.position.y - _startPlayerY, 0), 10 * Time.deltaTime);
    }

}

