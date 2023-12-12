using UnityEngine;
using UnityEngine.InputSystem;

public class OptionInput_2 : OptionInput
{
    void Start()
    {
        Input.PlayerActions.Option.started += OptionInGamePanel;
    }

    private void OptionInGamePanel(InputAction.CallbackContext context)
    {
        if (isOptionPanelOpen == false)
        {
            isOptionPanelOpen = true;
            _optionPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (isOptionPanelOpen == true)
        {
            isOptionPanelOpen = false;
            _optionPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }


    public void OptionPanel_2()
    {
        isOptionPanelOpen = true;
        _optionPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseOptionPanel_2()
    {
        Debug.Log("close");
        isSpacebarChecking = true;
        isOptionPanelOpen = false;
        _optionPanel.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(CheckingCoroutine());
    }
}
