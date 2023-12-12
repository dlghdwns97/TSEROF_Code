using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearScene : MonoBehaviour
{
    private void Awake()
    {
        DataPersistenceManager.instance.SaveGame();
    }
    private void Update()
    {
        StartCoroutine(NextScene());            
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(8.0f);
        ClearStage1();
    }

    public void ClearStage1()
    {
        GameManager.instance.isSpawn = true;
        SceneManager.LoadScene("StageSelect");
    }
}
