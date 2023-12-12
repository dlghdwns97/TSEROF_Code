using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1ClearCutScene : MonoBehaviour
{
    [SerializeField] GameObject stage1ClearCutScene;
    [SerializeField] GameObject changeScene;

    private void Update()
    {
        if(changeScene.activeSelf == true)
        {
            GameManager.instance.isFirstStageClear = true;
            SceneManager.LoadScene("StageSelect");
            GameManager.instance.isSpawn = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stage1ClearCutScene.SetActive(true);
        }
    }
}
