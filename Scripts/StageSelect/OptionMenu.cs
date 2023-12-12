using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : Menu
{
    OptionInput optionInput;

    [Header("OptionMenu Buttons")]
    [SerializeField] private Button returnGameButton;
    [SerializeField] private Button onSelectStage;
    [SerializeField] private Button exitGameButton;

    public void OnSelectStageClicked()
    {
        optionInput.OnStageSelect();
    }

    public void CloseOptionPanelClicked()
    {
        optionInput._optionPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnExitGameClicked()
    {
        Application.Quit();
    }
}
