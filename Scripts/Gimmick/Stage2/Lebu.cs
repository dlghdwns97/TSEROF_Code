using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lebu : MonoBehaviour
{
    private GameObject _Lebu;
    private bool _isMove;
    public Animator animator;
    [SerializeField] private GameObject iconObject;
    [SerializeField] private Player player;
    private void Start()
    {
        StartSetting();
    }

    private void Update()
    {
        LebuMove();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        StartCoroutine(MoveStart());
    //    }
    //}

    private IEnumerator MoveStart()
    {
        _isMove = true;
        yield return new WaitForSeconds(2f);
        _isMove = false;
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f); // + 조건
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f); // + 조건
        transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f); // + 조건
        transform.GetChild(3).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        transform.GetChild(4).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        transform.GetChild(5).gameObject.SetActive(true);
        Stage2Manager.instance.Stage2Start();

    }
    private void StartSetting()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(3).gameObject.SetActive(false);
        transform.GetChild(4).gameObject.SetActive(false);
        transform.GetChild(5).gameObject.SetActive(false);
       
        _Lebu = transform.GetChild(0).gameObject;
    }

    private void LebuMove()
    {
        if (_isMove)
            animator.SetBool("LeverUp", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        iconObject.SetActive(true);       
        player = other.GetComponent<Player>();

        if (player == null)
        {
            return;
        }

        player.Input.PlayerActions.Interaction.started += CheckLeverStarted;
    }

    private void OnTriggerExit(Collider other)
    {
        iconObject.SetActive(false);
        
        player = other.GetComponent<Player>();

        if (player == null)
        {
            return;
        }

        player.Input.PlayerActions.Interaction.started -= CheckLeverStarted;
    }

    private void CheckLeverStarted(InputAction.CallbackContext obj)
    {
        StartCoroutine(MoveStart());
    }
}

