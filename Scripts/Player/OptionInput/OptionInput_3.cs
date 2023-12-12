using UnityEngine;
using UnityEngine.InputSystem;

public class OptionInput_3 : OptionInput
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

    public void OptionPanel_3()
    {
        isOptionPanelOpen = true;
        _optionPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseOptionPanel_3()
    {
        isSpacebarChecking = true;
        isOptionPanelOpen = false;
        _optionPanel.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(CheckingCoroutine());
    }
}
