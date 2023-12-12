using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Rigidbody _player;

    public CamChange camChange;

    private GameManager _gameManager;

    public int curStage;

    public bool isRespawn = false;

    [SerializeField] private Vector3 respawnPosition;
    
    private void Awake()
    {
        _gameManager = GameManager.instance;
    }
    private void Start()
    {
        // _player = GetComponent<Rigidbody>();
        respawnPosition = transform.position;
    }
    private void Update()
    {
        curStage = _gameManager._curStage;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null && collision.CompareTag("DeadZone"))
        {
            Reset();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            transform.position = Stage2Manager.instance.curRespawnPosition;
        }
    }
    private void Reset()
    {
        isRespawn = true;
        if (curStage == 1)
        {
            _player.transform.position = new Vector3(-2, 2, 2);
            _player.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            camChange.CamReset();
        }
        else if (curStage == 2)
        {
            _player.transform.position = Stage2Manager.instance.curRespawnPosition;
            // _player.transform.position = new Vector3(-3.5f, -28.5f, -16f);
            _player.transform.rotation = Quaternion.Euler(new Vector3(0, -75f, 0));
        }
        else if (curStage == 3)
        {
            _player.transform.position = new Vector3(0, 2, 2);
            _player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
