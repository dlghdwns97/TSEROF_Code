using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class OptionInput : MonoBehaviour
{
    public PlayerInput Input { get; private set; }

    public GameObject _optionPanel;
    public bool isOptionPanelOpen = false;
    public bool isSpacebarChecking = false;

    [SerializeField] private MoveSelect _moveSelect;

    private void Awake()
    {
        Input = GetComponent<PlayerInput>();
    }
    void Start()
    {
        Input.PlayerActions.Option.started += OptionPanel;
    }

    private void OptionPanel(InputAction.CallbackContext context)
    {
        if (_moveSelect._isOptionUIOpen == false)
        {
            _moveSelect._isOptionUIOpen = true;
            _optionPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (_moveSelect._isOptionUIOpen == true)
        {
            _moveSelect._isOptionUIOpen = false;
            _optionPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void OptionPanel()
    {
        _moveSelect._isOptionUIOpen = true;
        isOptionPanelOpen = true;
        _optionPanel.SetActive(true);
        Time.timeScale = 0;
        
    }

    public void CloseOptionPanel()
    {
        _moveSelect._isOptionUIOpen = false;
        isOptionPanelOpen = false;
        _optionPanel.SetActive(false);
        isSpacebarChecking = true;
        Time.timeScale = 1;
        StartCoroutine(CheckingCoroutine());
    }

    public void OnStageSelect()
    {
        Time.timeScale = 1;
        GameManager.instance.isSpawn = true;
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene("StageSelect");
    }

    protected IEnumerator CheckingCoroutine()
    {
        yield return new WaitForSeconds(1f);
        isSpacebarChecking = false;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
