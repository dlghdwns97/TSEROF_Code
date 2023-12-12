using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(gameManager._curStage == 1)
            {
                gameManager.isFirstStageClear = true;
                SceneManager.LoadScene("StageSelect");
            }
            else if(gameManager._curStage == 2)
            { 
                gameManager.isSecondStageClear = true;
                SceneManager.LoadScene("StageSelect");
            }
            else if(gameManager._curStage == 3)
            {
                gameManager.isThirdStageClear = true;
                SceneManager.LoadScene("StageSelect");
            }
            gameManager.isSpawn = true;
            //SceneManager.LoadScene("StageSelect");
        }
    }
}
