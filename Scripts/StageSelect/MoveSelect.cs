using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSelect : MonoBehaviour
{
    [SerializeField] internal int curStage;
    static GameObject stage1UI;
    static GameObject stage2UI;
    static GameObject stage3UI;
    static GameObject startSceneUI;

    public GameObject[] stageUIs = new GameObject[4] { startSceneUI, stage1UI, stage2UI, stage3UI };

    [SerializeField] private GameObject optionUI;
    [SerializeField] private GameObject achivementUI;

    [SerializeField] private GameObject wayPoint0;
    [SerializeField] private GameObject wayPoint1;
    [SerializeField] private GameObject wayPoint2;
    [SerializeField] private GameObject wayPoint3;
    [SerializeField] private GameObject wayPoint4;
    [SerializeField] private GameObject wayPoint5;
    [SerializeField] private GameObject wayPoint6;
    [SerializeField] private GameObject wayPoint7;

    [SerializeField] private GameObject cantSelectStageUI;

    [SerializeField] private GameObject stage2PortalEffect;
    [SerializeField] private GameObject stage3PortalEffect;

    [SerializeField] private WaypointPath waypointPath1;

    [SerializeField] private float speed;

    [SerializeField] private OptionInput _optionInput;

    private int _targetWayPointIndex;

    private Transform _previousWayPoint;
    private Transform _targetWayPoint;

    private float _timeToWayPoint;
    private float _elapsedTime;

    [SerializeField] private bool isMove = false;
    private bool _isFront = true;
    public bool _isOptionUIOpen = false;
    private bool _isAchivementUIOpen = false;
    public bool isInputESC = false;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        DataPersistenceManager.instance.SaveGame();

    }

    private void Start()
    {
        if(GameManager.instance._curStage == 0)
        {
            stageUIs[0].SetActive(true);
        }
        else if(GameManager.instance._curStage != 0)
        {
            stageUIs[0].SetActive(false);
        }  
        stageUIs[1].SetActive(false);
        stageUIs[2].SetActive(false);
        stageUIs[3].SetActive(false);

        if(GameManager.instance.isFirstStageClear == false)
        {
            stage2PortalEffect.SetActive(false);
        }
        else
        {
            stage2PortalEffect.SetActive(true);
        }

        if (GameManager.instance.isSecondStageClear == false)
        {
            stage3PortalEffect.SetActive(false);
        }
        else
        {
            stage3PortalEffect.SetActive(true);
        }
        SceneManager.sceneLoaded += LoadedsceneEvent;

        wayPoint0.GetComponent<BoxCollider>().enabled = false;

        curStage = GameManager.instance._curStage;
    }

    private void LoadedsceneEvent(Scene arg0, LoadSceneMode arg1)
    {
        if (GameManager.instance.isSpawn == true)
        {
            if (arg0.name == "StageSelect")
            {
                CharacterSpawnPoint();
                isMove = false;
            }
            GameManager.instance.isSpawn = false;
        }
    }

    private void Update()
    {
        if (isMove == true)
        {
            _animator.SetBool("isMove", true);
        }
        else if(isMove == false)
        {
            _animator.SetBool("isMove", false);


            if (_isOptionUIOpen == false && _isAchivementUIOpen == false)
            {
                Move();
                SelectStage();
            }
            OpenAchivementUI();
        }

        curStage = GameManager.instance._curStage;
    }


    private void FixedUpdate()
    {
        if (isMove == true)
        {
            StartMove();
        }
        if (GameManager.instance.isSpawn == true)
        {
            CharacterSpawnPoint();
            GameManager.instance.isSpawn = false;
        }
    }

    private void TargetNextWayPoint()
    {
        _previousWayPoint = waypointPath1.GetWaypoint(_targetWayPointIndex);
        _targetWayPointIndex = waypointPath1.SelectGetNextWaypointIndex(_targetWayPointIndex);
        _targetWayPoint = waypointPath1.GetWaypoint(_targetWayPointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWayPoint.position, _targetWayPoint.position);
        _timeToWayPoint = distanceToWaypoint / speed;
    }
    private void TargetReverseWayPoint()
    {
        _previousWayPoint = waypointPath1.GetWaypoint(_targetWayPointIndex);
        _targetWayPointIndex = waypointPath1.SelectGetReverseWaypointIndex(_targetWayPointIndex);
        _targetWayPoint = waypointPath1.GetWaypoint(_targetWayPointIndex);

        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWayPoint.position, _targetWayPoint.position);
        _timeToWayPoint = distanceToWaypoint / speed;


    }
    

    private void OpenStageUI(int index)
    {
        for (int i = 0; i < stageUIs.Length; i++)
        {
            stageUIs[index].SetActive(true);
        }
    }

    private void CloseStageUI(int index)
    {
        for (int i = 0; i < stageUIs.Length; i++)
        {
            stageUIs[index].SetActive(false);
        }
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            isMove = true;
            _isFront = false;

            if (curStage == 1)
            {
                wayPoint0.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                wayPoint1.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                wayPoint2.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

                TargetReverseWayPoint();
            }
            else if (curStage == 2)
            {
                wayPoint2.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                wayPoint3.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                wayPoint4.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

                TargetReverseWayPoint();
            }
            else if (curStage == 3 || curStage == 0)
            {
                isMove = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isMove = true;
            
            if (curStage == 3)
            {
                _isFront = false;

                wayPoint4.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                wayPoint5.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                wayPoint6.transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
                wayPoint7.transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));

                TargetReverseWayPoint();
            }
            else if (curStage == 0)
            {
                _isFront = true;

                wayPoint0.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                wayPoint1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                wayPoint2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                TargetNextWayPoint();
            }
            else if (curStage == 1)
            {
                _isFront = true;

                wayPoint2.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                wayPoint3.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                wayPoint4.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

                TargetNextWayPoint();
            }
            else if (curStage == 2)
            {
                isMove = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            isMove = true;
            _isFront = true;

            if (curStage == 2)
            {
                wayPoint4.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                wayPoint5.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                wayPoint6.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                wayPoint7.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

                TargetNextWayPoint();
            }
            else
            {
                isMove = false;
            }
        }
    }

    private void SelectStage()
    {
        if(_optionInput.isSpacebarChecking == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (curStage == 1)
                {
                    SceneManager.LoadScene("Stage1Scene");
                }
                else if (curStage == 0)
                {
                    DataPersistenceManager.instance.SaveGame();
                    SceneManager.LoadScene("StartScene");
                }
                else if (curStage == 2)
                {
                    if (GameManager.instance.isFirstStageClear == true)
                    {
                        SceneManager.LoadScene("Stage2Scene");
                    }
                    else
                    {
                        StartCoroutine("CantSelectStageUI");
                    }
                }
                else if (curStage == 3)
                {
                    if (GameManager.instance.isSecondStageClear == true)
                    {
                        SceneManager.LoadScene("Stage3Scene");
                    }
                    else
                    {
                        StartCoroutine(CantSelectStageUI());
                    }
                }

            }
        }
        
    }

    private IEnumerator CantSelectStageUI() 
    {
        cantSelectStageUI.SetActive(true);

        yield return new WaitForSeconds(2f);
        cantSelectStageUI.SetActive(false);
    }

    public void OpenAchivementUI()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_isAchivementUIOpen == false)
            {
                achivementUI.SetActive(true);

                _isAchivementUIOpen = true;
            }
            else if (_isAchivementUIOpen == true)
            {
                achivementUI.SetActive(false);

                _isAchivementUIOpen = false;
            }
        }
    }

    public void OnClickOpenAchivemntUI()
    {
        if (_isAchivementUIOpen == false)
        {
            achivementUI.SetActive(true);

            _isAchivementUIOpen = true;
        }
    }

    public void OnClickCloseAchivemntUI()
    {
        if (_isAchivementUIOpen == true)
        {
            achivementUI.SetActive(false);

            _isAchivementUIOpen = false;
        }
    }

    private void StartMove()
    {
        _elapsedTime += Time.deltaTime;

        float elapsedPercentage = _elapsedTime / _timeToWayPoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(_previousWayPoint.position, _targetWayPoint.position, elapsedPercentage);
        transform.rotation = Quaternion.Lerp(_previousWayPoint.rotation, _targetWayPoint.rotation, elapsedPercentage * 4.5f - 3.5f);
        if (elapsedPercentage >= 1)
        {
            if (curStage == 0)
            {
                TargetNextWayPoint();
            }
            else if (curStage == 1 || curStage == 2)
            {
                if (_isFront == false)
                {
                    TargetReverseWayPoint();
                }
                else if (_isFront == true)
                {
                    TargetNextWayPoint();
                }
            }
            else if (curStage == 3)
            {
                TargetReverseWayPoint();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stage1"))
        {
            isMove = false;
            GameManager.instance.CurrentStage(1);
            _targetWayPointIndex = 2;
            OpenStageUI(1);
            if (wayPoint0.GetComponent<BoxCollider>().enabled == false)
            {
                wayPoint0.GetComponent<BoxCollider>().enabled = true;
            }
            CloseStageUI(0);
        }
        else if (other.CompareTag("Stage2"))
        {
            isMove = false;
            GameManager.instance.CurrentStage(2);
            _targetWayPointIndex = 4;
            OpenStageUI(2);
        }
        else if (other.CompareTag("Stage3"))
        {
            isMove = false;
            GameManager.instance.CurrentStage(3);
            _targetWayPointIndex = 7;
            OpenStageUI(3);
        }
        else if (other.CompareTag("Stage0"))
        {
            Debug.Log("ZERO");
            isMove = false;
            GameManager.instance.CurrentStage(0);
            _targetWayPointIndex = 0;
            OpenStageUI(0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Stage1"))
        {
            CloseStageUI(1);
        }
        else if (other.CompareTag("Stage2"))
        {
            CloseStageUI(2);
        }
        else if (other.CompareTag("Stage3"))
        {
            CloseStageUI(3);
        }
        else if (other.CompareTag("Stage0"))
        {
            CloseStageUI(0);
        }
    }

    public void CharacterSpawnPoint()
    {
        if(GameManager.instance._curStage == 0)
        {
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            _targetWayPointIndex = 0;
        }
        else if (GameManager.instance._curStage == 1)
        {
            transform.position = new Vector3(-5, 0, 5);
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            _targetWayPointIndex = 2;
        }
        else if (GameManager.instance._curStage == 2)
        {
            transform.position = new Vector3(-10, 0, 10);
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            _targetWayPointIndex = 4;
        }
        else if (GameManager.instance._curStage == 3)
        {
            transform.position = new Vector3(4, 8, 13);
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            _targetWayPointIndex = 7;
        }
    }
}
