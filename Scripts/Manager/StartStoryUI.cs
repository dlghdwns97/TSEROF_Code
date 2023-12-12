using System.Collections;
using UnityEngine;

public class StartStoryUI : MonoBehaviour
{

    public GameObject StoryUI;
    void Start()
    {
        Time.timeScale = 0f;
        GameManager.instance.isStartStoryFin = false;
        StoryUI.SetActive(true);
    }

    private void Update()
    {
        StartStorySkipESC();
    }

    public void StartStorySkipESC()
    {
        if(GameManager.instance.isStartStoryFin == false )
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StoryUI.SetActive(false);
                Time.timeScale = 1f;
                StartCoroutine(StartStoryFin());
            }
        }
        
    }

    private IEnumerator StartStoryFin()
    {
        yield return new WaitForSeconds(1f);

        GameManager.instance.isStartStoryFin = true;
    }

    public void StartStorySkipOnClik()
    {
        StoryUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
