using UnityEngine;
using UnityEngine.InputSystem;

public class OptionInput_1 : OptionInput
{
    void Start()
    {
        Input.PlayerActions.Option.started += OptionInGamePanel;
    }

    private void OptionInGamePanel(InputAction.CallbackContext context)
    {
        if (GameManager.instance.isStartStoryFin == true)
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
    }

    public void OptionPanel_1()
    {
        isOptionPanelOpen = true;
        _optionPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseOptionPanel_1()
    {
        isSpacebarChecking = true;
        isOptionPanelOpen = false;
        _optionPanel.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(CheckingCoroutine());
    }
}
