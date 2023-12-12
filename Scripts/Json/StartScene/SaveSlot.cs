using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private Text percentageCompleteText;

    [Header("Delete Data Button")] 
    [SerializeField] private Button deleteButton;

    public bool hasData { get; private set; } = false; 
    private Button _saveSlotButton;

    private void Awake()
    {
        _saveSlotButton = this.GetComponent<Button>();
    }

    public void SetData(GameData data)
    {
        if (data == null)
        {
            hasData = false;    
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
            deleteButton.gameObject.SetActive(false); 
        }
        else
        {
            hasData = true; 
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            deleteButton.gameObject.SetActive(true); 

            percentageCompleteText.text = "Puzzle " + data.GetPercentageComplete() + "% Complete";
        }

    }

    public string GetProfileId()
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        _saveSlotButton.interactable = interactable;
        deleteButton.interactable = interactable; 
    }
}
